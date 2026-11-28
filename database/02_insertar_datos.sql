-- =============================================
-- BASE DE DATOS: SumajPachaDB
-- Script 2 de 3: insertar datos
-- Ejecutar despues de 01_crear_tablas.sql
-- =============================================

USE SumajPachaDB;
GO

INSERT INTO COMUNIDAD (nombre, distrito, municipio)
VALUES ('Melga', NULL, 'Sacaba');

INSERT INTO PROYECTO (nombre, financiador, presupuesto, fecha_inicio)
VALUES ('Sumaj Pacha', 'Por definir con la ONG', 100000, '2026-09-01');

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
