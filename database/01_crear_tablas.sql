-- =============================================
-- BASE DE DATOS: SumajPachaDB
-- Sistema de seguimiento de huertos familiares "Sumaj Pacha"
-- ONG Yachay Chhalaku - Melga, Sacaba
-- Proyecto Integrador I - Grupo SolAndino
-- =============================================
-- Script 1 de 3: crea la base y las tablas
-- Orden para ejecutar en SQL Server Management Studio (F5):
--   01_crear_tablas.sql  ->  02_insertar_datos.sql
-- El 03_consultas.sql es solo para los reportes.
-- OJO: si la base ya existe se borra y se vuelve a crear.

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SumajPachaDB')
BEGIN
    ALTER DATABASE SumajPachaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SumajPachaDB;
END
GO

CREATE DATABASE SumajPachaDB;
GO

USE SumajPachaDB;
GO


-- ---------- TABLAS ----------

-- comunidades donde trabaja la ONG
CREATE TABLE COMUNIDAD (
    id_comunidad INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    distrito VARCHAR(50) NULL,
    municipio VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_comunidad UNIQUE (nombre, municipio)
);

-- proyectos de la ONG (por ahora solo esta Sumaj Pacha)
CREATE TABLE PROYECTO (
    id_proyecto INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    financiador VARCHAR(100) NOT NULL,
    presupuesto DECIMAL(12,2) NOT NULL CHECK (presupuesto >= 0),
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NULL,
    CHECK (fecha_fin IS NULL OR fecha_fin >= fecha_inicio)
);

-- cultivos que se entregan a las familias
CREATE TABLE CULTIVO (
    id_cultivo INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    dias_a_cosecha INT NOT NULL CHECK (dias_a_cosecha > 0),
    precio_ref_kg DECIMAL(10,2) NOT NULL CHECK (precio_ref_kg >= 0)  -- precio en Bs del kilo, sirve para calcular el ahorro
);

-- usuarios que pueden entrar al sistema
-- los roles son ADMIN, TECNICO y CONSULTA
CREATE TABLE USUARIO (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    cargo VARCHAR(100) NOT NULL,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,  -- no se guarda la contraseña, solo su hash (SHA-256)
    rol VARCHAR(20) NOT NULL CHECK (rol IN ('ADMIN', 'TECNICO', 'CONSULTA')),
    activo BIT NOT NULL DEFAULT 1
);

-- familias que participan en el proyecto
CREATE TABLE FAMILIA (
    id_familia INT IDENTITY(1,1) PRIMARY KEY,
    id_comunidad INT NOT NULL,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    sexo CHAR(1) NOT NULL CHECK (sexo IN ('F', 'M')),
    fecha_nacimiento DATE NOT NULL,
    nro_miembros INT NOT NULL CHECK (nro_miembros > 0),
    telefono VARCHAR(20) NULL,
    fecha_registro DATE NOT NULL DEFAULT GETDATE(),
    fecha_consentimiento DATE NOT NULL,  -- fecha en que la familia firmo el consentimiento
    CONSTRAINT FK_familia_comunidad FOREIGN KEY (id_comunidad) REFERENCES COMUNIDAD(id_comunidad)
);

-- parcelas de cada familia, pueden ser huerto o SAF (sistema agroforestal)
CREATE TABLE PARCELA (
    id_parcela INT IDENTITY(1,1) PRIMARY KEY,
    id_familia INT NOT NULL,
    id_proyecto INT NOT NULL,
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('HUERTO', 'SAF')),
    superficie_m2 DECIMAL(8,2) NOT NULL CHECK (superficie_m2 > 0),
    tiene_riego BIT NOT NULL DEFAULT 0,
    fecha_instalacion DATE NOT NULL,
    CONSTRAINT FK_parcela_familia FOREIGN KEY (id_familia) REFERENCES FAMILIA(id_familia),
    CONSTRAINT FK_parcela_proyecto FOREIGN KEY (id_proyecto) REFERENCES PROYECTO(id_proyecto)
);

-- lo que se les entrega: plantines, abono, bioinsumos
-- el abono no es de ningun cultivo, por eso id_cultivo puede quedar en NULL
CREATE TABLE INSUMO (
    id_insumo INT IDENTITY(1,1) PRIMARY KEY,
    id_cultivo INT NULL,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('PLANTIN', 'ABONO', 'BIOINSUMO')),
    unidad_medida VARCHAR(20) NOT NULL,
    costo_unitario DECIMAL(10,2) NOT NULL CHECK (costo_unitario >= 0),
    es_organico BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_insumo_cultivo FOREIGN KEY (id_cultivo) REFERENCES CULTIVO(id_cultivo)
);

-- entregas de insumos a cada parcela
-- una entrega no se borra, solo se anula (anulado = 1)
CREATE TABLE ENTREGA (
    id_entrega INT IDENTITY(1,1) PRIMARY KEY,
    id_parcela INT NOT NULL,
    id_insumo INT NOT NULL,
    id_usuario INT NOT NULL,  -- tecnico que hizo la entrega
    fecha DATE NOT NULL CHECK (fecha <= GETDATE()),
    cantidad DECIMAL(10,2) NOT NULL CHECK (cantidad > 0),
    anulado BIT NOT NULL DEFAULT 0,
    id_usuario_anula INT NULL,  -- quien la anulo
    fecha_anulacion DATETIME NULL,  -- cuando se anulo
    CONSTRAINT FK_entrega_parcela FOREIGN KEY (id_parcela) REFERENCES PARCELA(id_parcela),
    CONSTRAINT FK_entrega_insumo FOREIGN KEY (id_insumo) REFERENCES INSUMO(id_insumo),
    CONSTRAINT FK_entrega_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario),
    CONSTRAINT FK_entrega_usuario_anula FOREIGN KEY (id_usuario_anula) REFERENCES USUARIO(id_usuario)
);

-- visitas tecnicas a las parcelas
CREATE TABLE VISITA (
    id_visita INT IDENTITY(1,1) PRIMARY KEY,
    id_parcela INT NOT NULL,
    id_usuario INT NOT NULL,
    fecha DATE NOT NULL CHECK (fecha <= GETDATE()),
    estado_parcela VARCHAR(20) NOT NULL CHECK (estado_parcela IN ('BUENO', 'REGULAR', 'MALO')),
    observacion VARCHAR(255) NULL,
    anulado BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_visita_parcela FOREIGN KEY (id_parcela) REFERENCES PARCELA(id_parcela),
    CONSTRAINT FK_visita_usuario FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

-- en cada visita se cuentan las plantas vivas y los kg cosechados de cada cultivo
CREATE TABLE SEGUIMIENTO_CULTIVO (
    id_seguimiento INT IDENTITY(1,1) PRIMARY KEY,
    id_visita INT NOT NULL,
    id_cultivo INT NOT NULL,
    plantas_vivas INT NOT NULL CHECK (plantas_vivas >= 0),
    kg_cosechados DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (kg_cosechados >= 0),
    CONSTRAINT UQ_seguimiento UNIQUE (id_visita, id_cultivo),  -- un cultivo solo una vez por visita
    CONSTRAINT FK_seguimiento_visita FOREIGN KEY (id_visita) REFERENCES VISITA(id_visita),
    CONSTRAINT FK_seguimiento_cultivo FOREIGN KEY (id_cultivo) REFERENCES CULTIVO(id_cultivo)
);

-- alertas cuando la supervivencia baja
-- menos de 81% = MEDIO, menos de 72% = CRITICO
CREATE TABLE ALERTA (
    id_alerta INT IDENTITY(1,1) PRIMARY KEY,
    id_visita INT NOT NULL,
    supervivencia DECIMAL(5,2) NOT NULL CHECK (supervivencia BETWEEN 0 AND 100),
    umbral_aplicado DECIMAL(5,2) NOT NULL,
    nivel_riesgo VARCHAR(10) NOT NULL CHECK (nivel_riesgo IN ('MEDIO', 'CRITICO')),
    fecha_generacion DATETIME NOT NULL DEFAULT GETDATE(),
    revisada BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_alerta_visita FOREIGN KEY (id_visita) REFERENCES VISITA(id_visita)
);
GO


-- ---------- TRIGGERS ----------
-- para que no se puedan borrar las entregas ni las visitas (solo anular)

CREATE TRIGGER tr_no_borrar_entrega
ON ENTREGA
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('No se puede borrar una entrega, solo se puede anular', 16, 1);
END
GO

CREATE TRIGGER tr_no_borrar_visita
ON VISITA
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('No se puede borrar una visita, solo se puede anular', 16, 1);
END
GO
