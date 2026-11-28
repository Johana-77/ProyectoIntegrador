-- =============================================
-- BASE DE DATOS: SumajPachaDB
-- Script 2 de 3: insertar datos
-- Ejecutar despues de 01_crear_tablas.sql
-- =============================================

USE SumajPachaDB;
GO

INSERT INTO COMUNIDAD (nombre, distrito, municipio)
VALUES ('Melga', NULL, 'Sacaba');

-- proyecto Sumaj Pacha, financiado por la CEI (2026 - 2028)
-- el presupuesto es un dato que maneja la ONG, por eso queda en NULL
INSERT INTO PROYECTO (nombre, financiador, presupuesto, fecha_inicio, fecha_fin)
VALUES ('Sumaj Pacha', 'Conferencia Episcopal Italiana (CEI)', NULL, '2026-01-01', '2028-12-31');

INSERT INTO CULTIVO (nombre, dias_a_cosecha, precio_ref_kg) VALUES
('Brócoli', 90, 4.00),
('Coliflor', 100, 4.00),
('Repollo', 110, 4.00),
('Lechuga', 60, 4.00);

INSERT INTO INSUMO (id_cultivo, nombre, tipo, unidad_medida, costo_unitario, es_organico) VALUES
(1, 'Plantín de brócoli', 'PLANTIN', 'unidad', 0.50, 1),
(2, 'Plantín de coliflor', 'PLANTIN', 'unidad', 0.50, 1),
(3, 'Plantín de repollo', 'PLANTIN', 'unidad', 0.50, 1),
(4, 'Plantín de lechuga', 'PLANTIN', 'unidad', 0.50, 1),
(NULL, 'Abono orgánico (bocashi)', 'ABONO', 'kg', 2.00, 1);

-- cuentas iniciales del sistema, una por cada rol
-- la contraseña inicial es 1234 (se guarda con SHA-256), hay que cambiarla al instalar
-- las cuentas de cada trabajador las crea el administrador desde el sistema
INSERT INTO USUARIO (nombre, cargo, usuario, contrasena_hash, rol, activo) VALUES
('Usuario Administrador', 'Administrador del sistema', 'admin', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'ADMIN', 1),
('Usuario Técnico', 'Técnico de campo', 'tecnico', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'TECNICO', 1),
('Usuario Consulta', 'Solo consulta', 'consulta', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'CONSULTA', 1);

-- 10 familias de Melga (los nombres son ficticios para proteger sus datos personales)
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento, nro_miembros, fecha_consentimiento) VALUES
(1, 'María Elena', 'Quispe Mamani', 'F', '1985-04-12', 5, '2026-09-01'),
(1, 'Juan', 'Choque Rocha', 'M', '1978-08-30', 4, '2026-09-01'),
(1, 'Lidia', 'Flores Siles', 'F', '1992-01-15', 6, '2026-09-01'),
(1, 'Teodora', 'Gonzales Condori', 'F', '1969-11-02', 3, '2026-09-01'),
(1, 'Freddy', 'Rojas Ayala', 'M', '1988-06-21', 5, '2026-09-01'),
(1, 'Carla', 'Arnez Quiroga', 'F', '1999-03-09', 4, '2026-09-01'),
(1, 'Celestino', 'Huanca Torrico', 'M', '1960-12-05', 2, '2026-09-01'),
(1, 'Justina', 'Copa Villarroel', 'F', '1983-07-18', 5, '2026-09-01'),
(1, 'Basilia', 'Terceros Mendoza', 'F', '1975-02-27', 4, '2026-09-01'),
(1, 'Edwin', 'Soliz Camacho', 'M', '1995-10-10', 3, '2026-09-01');

-- una parcela por familia, todas son huertos de 150 m2 con riego
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion) VALUES
(1, 1, 'HUERTO', 150, 1, '2026-09-05'),
(2, 1, 'HUERTO', 150, 1, '2026-09-05'),
(3, 1, 'HUERTO', 150, 1, '2026-09-05'),
(4, 1, 'HUERTO', 150, 1, '2026-09-05'),
(5, 1, 'HUERTO', 150, 1, '2026-09-05'),
(6, 1, 'HUERTO', 150, 1, '2026-09-05'),
(7, 1, 'HUERTO', 150, 1, '2026-09-05'),
(8, 1, 'HUERTO', 150, 1, '2026-09-05'),
(9, 1, 'HUERTO', 150, 1, '2026-09-05'),
(10, 1, 'HUERTO', 150, 1, '2026-09-05');

-- a cada parcela se le dio 40 plantines de cada cultivo y 4.5 kg de abono
-- las entregas y las visitas las registro el usuario tecnico (id 2)
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(1, 1, 2, '2026-09-05', 40), (1, 2, 2, '2026-09-05', 40), (1, 3, 2, '2026-09-05', 40), (1, 4, 2, '2026-09-05', 40), (1, 5, 2, '2026-09-05', 4.5),
(2, 1, 2, '2026-09-05', 40), (2, 2, 2, '2026-09-05', 40), (2, 3, 2, '2026-09-05', 40), (2, 4, 2, '2026-09-05', 40), (2, 5, 2, '2026-09-05', 4.5),
(3, 1, 2, '2026-09-05', 40), (3, 2, 2, '2026-09-05', 40), (3, 3, 2, '2026-09-05', 40), (3, 4, 2, '2026-09-05', 40), (3, 5, 2, '2026-09-05', 4.5),
(4, 1, 2, '2026-09-05', 40), (4, 2, 2, '2026-09-05', 40), (4, 3, 2, '2026-09-05', 40), (4, 4, 2, '2026-09-05', 40), (4, 5, 2, '2026-09-05', 4.5),
(5, 1, 2, '2026-09-05', 40), (5, 2, 2, '2026-09-05', 40), (5, 3, 2, '2026-09-05', 40), (5, 4, 2, '2026-09-05', 40), (5, 5, 2, '2026-09-05', 4.5),
(6, 1, 2, '2026-09-05', 40), (6, 2, 2, '2026-09-05', 40), (6, 3, 2, '2026-09-05', 40), (6, 4, 2, '2026-09-05', 40), (6, 5, 2, '2026-09-05', 4.5),
(7, 1, 2, '2026-09-05', 40), (7, 2, 2, '2026-09-05', 40), (7, 3, 2, '2026-09-05', 40), (7, 4, 2, '2026-09-05', 40), (7, 5, 2, '2026-09-05', 4.5),
(8, 1, 2, '2026-09-05', 40), (8, 2, 2, '2026-09-05', 40), (8, 3, 2, '2026-09-05', 40), (8, 4, 2, '2026-09-05', 40), (8, 5, 2, '2026-09-05', 4.5),
(9, 1, 2, '2026-09-05', 40), (9, 2, 2, '2026-09-05', 40), (9, 3, 2, '2026-09-05', 40), (9, 4, 2, '2026-09-05', 40), (9, 5, 2, '2026-09-05', 4.5),
(10, 1, 2, '2026-09-05', 40), (10, 2, 2, '2026-09-05', 40), (10, 3, 2, '2026-09-05', 40), (10, 4, 2, '2026-09-05', 40), (10, 5, 2, '2026-09-05', 4.5);

-- primera visita a cada parcela, un mes despues de la entrega
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela, observacion) VALUES
(1, 2, '2026-10-05', 'BUENO', 'Las plantas estan bien'),
(2, 2, '2026-10-05', 'BUENO', NULL),
(3, 2, '2026-10-05', 'BUENO', 'La familia riega todos los dias'),
(4, 2, '2026-10-05', 'BUENO', 'Se recomendo poner mas abono'),
(5, 2, '2026-10-05', 'BUENO', NULL),
(6, 2, '2026-10-05', 'BUENO', NULL),
(7, 2, '2026-10-05', 'REGULAR', 'Varias plantas se secaron, hay que revisar el riego'),
(8, 2, '2026-10-05', 'BUENO', 'Buen avance'),
(9, 2, '2026-10-05', 'BUENO', 'Algunas lechugas con pulgon'),
(10, 2, '2026-10-05', 'BUENO', NULL);

-- plantas vivas de cada cultivo en esa visita (todavia no hay cosecha)
-- cultivos: 1 brocoli, 2 coliflor, 3 repollo, 4 lechuga
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(1, 1, 36, 0), (1, 2, 36, 0), (1, 3, 36, 0), (1, 4, 35, 0),
(2, 1, 38, 0), (2, 2, 38, 0), (2, 3, 37, 0), (2, 4, 37, 0),
(3, 1, 39, 0), (3, 2, 38, 0), (3, 3, 38, 0), (3, 4, 38, 0),
(4, 1, 36, 0), (4, 2, 35, 0), (4, 3, 35, 0), (4, 4, 35, 0),
(5, 1, 36, 0), (5, 2, 36, 0), (5, 3, 36, 0), (5, 4, 35, 0),
(6, 1, 39, 0), (6, 2, 39, 0), (6, 3, 38, 0), (6, 4, 38, 0),
(7, 1, 31, 0), (7, 2, 31, 0), (7, 3, 30, 0), (7, 4, 30, 0),
(8, 1, 39, 0), (8, 2, 38, 0), (8, 3, 38, 0), (8, 4, 38, 0),
(9, 1, 36, 0), (9, 2, 36, 0), (9, 3, 36, 0), (9, 4, 35, 0),
(10, 1, 35, 0), (10, 2, 35, 0), (10, 3, 34, 0), (10, 4, 34, 0);

-- la parcela 7 quedo con 122 de 160 plantas = 76.25%, esta debajo del 81% entonces sale alerta
INSERT INTO ALERTA (id_visita, supervivencia, umbral_aplicado, nivel_riesgo, fecha_generacion)
VALUES (7, 76.25, 81, 'MEDIO', '2026-10-05');
GO


-- para ver que todo se cargo bien
SELECT * FROM USUARIO;
SELECT * FROM FAMILIA;
SELECT * FROM PARCELA;
