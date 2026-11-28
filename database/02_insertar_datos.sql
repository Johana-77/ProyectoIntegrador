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
