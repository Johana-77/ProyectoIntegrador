-- Datos de prueba (valores supuestos) - SumajPachaDB
USE SumajPachaDB;
GO
INSERT INTO COMUNIDAD (nombre, distrito, municipio) VALUES ('Melga', NULL, 'Sacaba');
INSERT INTO PROYECTO (nombre, financiador, presupuesto, fecha_inicio)
VALUES ('Sumaj Pacha', 'Financiador del proyecto', 100000, '2026-09-01');
INSERT INTO CULTIVO (nombre, dias_a_cosecha, precio_ref_kg) VALUES
('Brócoli', 90, 4.00), ('Coliflor', 100, 4.00), ('Repollo', 110, 4.00), ('Lechuga', 60, 4.00);
INSERT INTO INSUMO (id_cultivo, nombre, tipo, unidad_medida, costo_unitario, es_organico) VALUES
(1, 'Plantín de brócoli', 'PLANTIN', 'unidad', 0.50, 1),
(2, 'Plantín de coliflor', 'PLANTIN', 'unidad', 0.50, 1),
(3, 'Plantín de repollo', 'PLANTIN', 'unidad', 0.50, 1),
(4, 'Plantín de lechuga', 'PLANTIN', 'unidad', 0.50, 1),
(NULL, 'Abono orgánico (bocashi)', 'ABONO', 'kg', 2.00, 1);
INSERT INTO USUARIO (nombre, cargo, usuario, contrasena_hash, rol)
VALUES ('Técnico de prueba', 'Técnico de campo', 'tecnico1',
        '$2a$11$hash.bcrypt.de.ejemplo', 'TECNICO');

-- Familia 01
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 01', 'F', '1985-04-12', 5, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (1, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(1, 1, 1, '2026-09-05', 40), (1, 2, 1, '2026-09-05', 40), (1, 3, 1, '2026-09-05', 40),
(1, 4, 1, '2026-09-05', 40), (1, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (1, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(1, 1, 36, 0), (1, 2, 36, 0), (1, 3, 36, 0), (1, 4, 35, 0);

-- Familia 02
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 02', 'M', '1978-08-30', 4, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (2, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(2, 1, 1, '2026-09-05', 40), (2, 2, 1, '2026-09-05', 40), (2, 3, 1, '2026-09-05', 40),
(2, 4, 1, '2026-09-05', 40), (2, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (2, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(2, 1, 38, 0), (2, 2, 38, 0), (2, 3, 37, 0), (2, 4, 37, 0);

-- Familia 03
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 03', 'F', '1992-01-15', 6, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (3, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(3, 1, 1, '2026-09-05', 40), (3, 2, 1, '2026-09-05', 40), (3, 3, 1, '2026-09-05', 40),
(3, 4, 1, '2026-09-05', 40), (3, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (3, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(3, 1, 39, 0), (3, 2, 38, 0), (3, 3, 38, 0), (3, 4, 38, 0);

-- Familia 04
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 04', 'F', '1969-11-02', 3, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (4, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(4, 1, 1, '2026-09-05', 40), (4, 2, 1, '2026-09-05', 40), (4, 3, 1, '2026-09-05', 40),
(4, 4, 1, '2026-09-05', 40), (4, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (4, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(4, 1, 36, 0), (4, 2, 35, 0), (4, 3, 35, 0), (4, 4, 35, 0);

-- Familia 05
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 05', 'M', '1988-06-21', 5, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (5, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(5, 1, 1, '2026-09-05', 40), (5, 2, 1, '2026-09-05', 40), (5, 3, 1, '2026-09-05', 40),
(5, 4, 1, '2026-09-05', 40), (5, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (5, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(5, 1, 36, 0), (5, 2, 36, 0), (5, 3, 36, 0), (5, 4, 35, 0);

-- Familia 06
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 06', 'F', '1999-03-09', 4, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (6, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(6, 1, 1, '2026-09-05', 40), (6, 2, 1, '2026-09-05', 40), (6, 3, 1, '2026-09-05', 40),
(6, 4, 1, '2026-09-05', 40), (6, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (6, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(6, 1, 39, 0), (6, 2, 39, 0), (6, 3, 38, 0), (6, 4, 38, 0);

-- Familia 07
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 07', 'M', '1960-12-05', 2, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (7, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(7, 1, 1, '2026-09-05', 40), (7, 2, 1, '2026-09-05', 40), (7, 3, 1, '2026-09-05', 40),
(7, 4, 1, '2026-09-05', 40), (7, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (7, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(7, 1, 31, 0), (7, 2, 31, 0), (7, 3, 30, 0), (7, 4, 30, 0);

-- Familia 08
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 08', 'F', '1983-07-18', 5, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (8, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(8, 1, 1, '2026-09-05', 40), (8, 2, 1, '2026-09-05', 40), (8, 3, 1, '2026-09-05', 40),
(8, 4, 1, '2026-09-05', 40), (8, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (8, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(8, 1, 39, 0), (8, 2, 38, 0), (8, 3, 38, 0), (8, 4, 38, 0);

-- Familia 09
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 09', 'F', '1975-02-27', 4, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (9, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(9, 1, 1, '2026-09-05', 40), (9, 2, 1, '2026-09-05', 40), (9, 3, 1, '2026-09-05', 40),
(9, 4, 1, '2026-09-05', 40), (9, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (9, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(9, 1, 36, 0), (9, 2, 36, 0), (9, 3, 36, 0), (9, 4, 35, 0);

-- Familia 10
INSERT INTO FAMILIA (id_comunidad, nombres, apellidos, sexo, fecha_nacimiento,
                     nro_miembros, fecha_consentimiento)
VALUES (1, 'Familia', 'Prueba 10', 'M', '1995-10-10', 3, '2026-09-01');
INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion)
VALUES (10, 1, 'HUERTO', 150, 1, '2026-09-05');
INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) VALUES
(10, 1, 1, '2026-09-05', 40), (10, 2, 1, '2026-09-05', 40), (10, 3, 1, '2026-09-05', 40),
(10, 4, 1, '2026-09-05', 40), (10, 5, 1, '2026-09-05', 4.5);
INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela)
VALUES (10, 1, '2026-10-05', 'BUENO');
INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) VALUES
(10, 1, 35, 0), (10, 2, 35, 0), (10, 3, 34, 0), (10, 4, 34, 0);
