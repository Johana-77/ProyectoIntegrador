-- Consultas principales del sistema - SumajPachaDB
USE SumajPachaDB;
GO

-- Q1. Supervivencia por parcela en su última visita (RF-05)
SELECT P.id_parcela,
       E.entregados,
       S.vivas,
       CAST(100.0 * S.vivas / E.entregados AS DECIMAL(5,2)) AS supervivencia_pct
FROM PARCELA P
JOIN (SELECT EN.id_parcela, SUM(EN.cantidad) AS entregados
      FROM ENTREGA EN
      JOIN INSUMO I ON I.id_insumo = EN.id_insumo
      WHERE I.tipo = 'PLANTIN' AND EN.anulado = 0
      GROUP BY EN.id_parcela) E ON E.id_parcela = P.id_parcela
JOIN (SELECT V.id_parcela, SUM(SC.plantas_vivas) AS vivas
      FROM VISITA V
      JOIN SEGUIMIENTO_CULTIVO SC ON SC.id_visita = V.id_visita
      WHERE V.anulado = 0
        AND V.fecha = (SELECT MAX(V2.fecha) FROM VISITA V2
                       WHERE V2.id_parcela = V.id_parcela AND V2.anulado = 0)
      GROUP BY V.id_parcela) S ON S.id_parcela = P.id_parcela
ORDER BY supervivencia_pct;

-- Q2. Familias y personas por comunidad, sexo y rango de edad (RF-06)
WITH F AS (
    SELECT id_comunidad, sexo, nro_miembros,
           DATEDIFF(YEAR, fecha_nacimiento, GETDATE())
           - CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, fecha_nacimiento, GETDATE()),
                               fecha_nacimiento) > GETDATE() THEN 1 ELSE 0 END AS edad
    FROM FAMILIA)
SELECT C.nombre AS comunidad, F.sexo,
       CASE WHEN F.edad < 30 THEN '18-29' WHEN F.edad < 45 THEN '30-44'
            WHEN F.edad < 60 THEN '45-59' ELSE '60 o más' END AS rango_edad,
       COUNT(*) AS familias,
       SUM(F.nro_miembros) AS personas
FROM F
JOIN COMUNIDAD C ON C.id_comunidad = F.id_comunidad
GROUP BY C.nombre, F.sexo,
       CASE WHEN F.edad < 30 THEN '18-29' WHEN F.edad < 45 THEN '30-44'
            WHEN F.edad < 60 THEN '45-59' ELSE '60 o más' END
ORDER BY comunidad, F.sexo, rango_edad;

-- Q3. Rendimiento y ahorro familiar por parcela (RF-05)
SELECT P.id_parcela, P.superficie_m2,
       SUM(SC.kg_cosechados) AS kg_cosechados,
       CAST(SUM(SC.kg_cosechados) / P.superficie_m2 AS DECIMAL(6,2)) AS rendimiento_kg_m2,
       SUM(SC.kg_cosechados * CU.precio_ref_kg) AS ahorro_bs
FROM PARCELA P
JOIN VISITA V ON V.id_parcela = P.id_parcela AND V.anulado = 0
JOIN SEGUIMIENTO_CULTIVO SC ON SC.id_visita = V.id_visita
JOIN CULTIVO CU ON CU.id_cultivo = SC.id_cultivo
GROUP BY P.id_parcela, P.superficie_m2;

-- Q4. CO2 evitado por usar abono orgánico en lugar de urea (RF-05, ODS 13)
DECLARE @dosis_urea DECIMAL(6,3) = 0.030;   -- kg de urea por m2 (referencia)
SELECT SUM(P.superficie_m2) * @dosis_urea                     AS urea_evitada_kg,
       SUM(P.superficie_m2) * @dosis_urea * 0.20 * 44 / 12    AS co2_evitado_kg
FROM PARCELA P
WHERE EXISTS (SELECT 1
              FROM ENTREGA E
              JOIN INSUMO I ON I.id_insumo = E.id_insumo
              WHERE E.id_parcela = P.id_parcela AND E.anulado = 0
                AND I.es_organico = 1 AND I.tipo IN ('ABONO','BIOINSUMO'));

-- Q5. Alertas pendientes de revisión, primero las críticas
SELECT A.id_alerta, V.id_parcela, V.fecha, A.supervivencia,
       A.umbral_aplicado, A.nivel_riesgo
FROM ALERTA A
JOIN VISITA V ON V.id_visita = A.id_visita
WHERE A.revisada = 0 AND V.anulado = 0
ORDER BY CASE A.nivel_riesgo WHEN 'CRITICO' THEN 1 ELSE 2 END, V.fecha;

-- Q6. Anulación lógica de una entrega (solo ADMIN; ejemplo): se marca, no se borra
DECLARE @id_entrega INT = 3;
UPDATE ENTREGA SET anulado = 1 WHERE id_entrega = @id_entrega;
