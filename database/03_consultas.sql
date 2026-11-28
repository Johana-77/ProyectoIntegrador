-- =============================================
-- BASE DE DATOS: SumajPachaDB
-- Script 3 de 3: consultas
-- =============================================
-- son las consultas que usamos para los reportes del proyecto
-- no hace falta ejecutarlas para que el sistema funcione

USE SumajPachaDB;
GO

-- 1. lista de familias con su comunidad
SELECT F.id_familia, F.nombres, F.apellidos, F.sexo, F.nro_miembros, C.nombre AS comunidad
FROM FAMILIA F
INNER JOIN COMUNIDAD C ON F.id_comunidad = C.id_comunidad
ORDER BY F.id_familia;

-- 2. supervivencia de cada parcela
-- supervivencia = plantas vivas en la ultima visita / plantines entregados * 100
SELECT T.id_parcela, CAST(T.entregados AS INT) AS entregados, T.vivas,
       CAST(T.vivas * 100.0 / T.entregados AS DECIMAL(5,1)) AS supervivencia
FROM (
    SELECT P.id_parcela,
        (SELECT SUM(E.cantidad)
         FROM ENTREGA E
         INNER JOIN INSUMO I ON E.id_insumo = I.id_insumo
         WHERE E.id_parcela = P.id_parcela AND I.tipo = 'PLANTIN' AND E.anulado = 0) AS entregados,
        (SELECT SUM(S.plantas_vivas)
         FROM SEGUIMIENTO_CULTIVO S
         INNER JOIN VISITA V ON S.id_visita = V.id_visita
         WHERE V.id_parcela = P.id_parcela AND V.anulado = 0
           AND V.fecha = (SELECT MAX(V2.fecha) FROM VISITA V2
                          WHERE V2.id_parcela = P.id_parcela AND V2.anulado = 0)) AS vivas
    FROM PARCELA P
) T
ORDER BY supervivencia;

-- 3. alertas que todavia no se revisaron
SELECT A.id_alerta, V.id_parcela, V.fecha, A.supervivencia, A.nivel_riesgo
FROM ALERTA A
INNER JOIN VISITA V ON A.id_visita = V.id_visita
WHERE A.revisada = 0 AND V.anulado = 0
ORDER BY A.supervivencia;

-- 4. cuantas familias y personas hay por comunidad y por sexo
SELECT C.nombre AS comunidad, F.sexo, COUNT(*) AS familias, SUM(F.nro_miembros) AS personas
FROM FAMILIA F
INNER JOIN COMUNIDAD C ON F.id_comunidad = C.id_comunidad
GROUP BY C.nombre, F.sexo;

-- 5. familias por rango de edad
SELECT T.rango_edad, COUNT(*) AS familias
FROM (
    SELECT CASE
             WHEN DATEDIFF(YEAR, fecha_nacimiento, GETDATE()) < 30 THEN '18-29'
             WHEN DATEDIFF(YEAR, fecha_nacimiento, GETDATE()) < 45 THEN '30-44'
             WHEN DATEDIFF(YEAR, fecha_nacimiento, GETDATE()) < 60 THEN '45-59'
             ELSE '60 o mas'
           END AS rango_edad
    FROM FAMILIA
) T
GROUP BY T.rango_edad;

-- 6. kilos cosechados, rendimiento y ahorro de cada parcela
-- ahorro = kg cosechados * precio de referencia del cultivo
SELECT P.id_parcela, F.apellidos,
       SUM(S.kg_cosechados) AS kg_cosechados,
       CAST(SUM(S.kg_cosechados) / P.superficie_m2 AS DECIMAL(10,2)) AS rendimiento_kg_m2,
       SUM(S.kg_cosechados * C.precio_ref_kg) AS ahorro_bs
FROM PARCELA P
INNER JOIN FAMILIA F ON P.id_familia = F.id_familia
INNER JOIN VISITA V ON V.id_parcela = P.id_parcela
INNER JOIN SEGUIMIENTO_CULTIVO S ON S.id_visita = V.id_visita
INNER JOIN CULTIVO C ON S.id_cultivo = C.id_cultivo
WHERE V.anulado = 0
GROUP BY P.id_parcela, F.apellidos, P.superficie_m2;

-- 7. CO2 que se evita por usar abono organico en vez de urea
-- tomamos 0.030 kg de urea por m2
-- la urea tiene 20% de carbono y 1 kg de carbono son 44/12 kg de CO2
DECLARE @urea_por_m2 DECIMAL(6,3) = 0.030;

SELECT CAST(SUM(P.superficie_m2) * @urea_por_m2 AS DECIMAL(10,2)) AS urea_evitada_kg,
       CAST(SUM(P.superficie_m2) * @urea_por_m2 * 0.20 * 44 / 12 AS DECIMAL(10,2)) AS co2_evitado_kg
FROM PARCELA P
WHERE P.id_parcela IN (SELECT E.id_parcela
                       FROM ENTREGA E
                       INNER JOIN INSUMO I ON E.id_insumo = I.id_insumo
                       WHERE E.anulado = 0 AND I.es_organico = 1 AND I.tipo IN ('ABONO', 'BIOINSUMO'));

-- 8. para anular una entrega (no se borra, solo se marca como anulada)
-- se deja comentado para no anular nada sin querer
-- UPDATE ENTREGA SET anulado = 1, id_usuario_anula = 1, fecha_anulacion = GETDATE() WHERE id_entrega = 3;
