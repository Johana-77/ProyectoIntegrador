-- Sistema de Seguimiento de Huertos Familiares (Sumaj Pacha) - SQL Server Express
CREATE DATABASE SumajPachaDB;
GO
USE SumajPachaDB;
GO

CREATE TABLE COMUNIDAD (
    id_comunidad  INT IDENTITY(1,1) PRIMARY KEY,
    nombre        VARCHAR(100) NOT NULL,
    distrito      VARCHAR(50)  NULL,
    municipio     VARCHAR(50)  NOT NULL,
    CONSTRAINT UQ_COMUNIDAD UNIQUE (nombre, municipio)
);

CREATE TABLE PROYECTO (
    id_proyecto   INT IDENTITY(1,1) PRIMARY KEY,
    nombre        VARCHAR(150)  NOT NULL,
    financiador   VARCHAR(100)  NOT NULL,
    presupuesto   DECIMAL(12,2) NOT NULL CHECK (presupuesto >= 0),
    fecha_inicio  DATE NOT NULL,
    fecha_fin     DATE NULL,
    CONSTRAINT CK_PROYECTO_fechas CHECK (fecha_fin IS NULL OR fecha_fin >= fecha_inicio)
);

CREATE TABLE CULTIVO (
    id_cultivo     INT IDENTITY(1,1) PRIMARY KEY,
    nombre         VARCHAR(50)   NOT NULL UNIQUE,
    dias_a_cosecha INT           NOT NULL CHECK (dias_a_cosecha > 0),
    precio_ref_kg  DECIMAL(10,2) NOT NULL CHECK (precio_ref_kg >= 0)
);

CREATE TABLE USUARIO (
    id_usuario      INT IDENTITY(1,1) PRIMARY KEY,
    nombre          VARCHAR(100) NOT NULL,
    cargo           VARCHAR(100) NOT NULL,
    usuario         VARCHAR(50)  NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,   -- hash bcrypt, nunca texto plano
    rol             VARCHAR(20)  NOT NULL CHECK (rol IN ('ADMIN','TECNICO','CONSULTA')),
    activo          BIT NOT NULL DEFAULT 1
);

CREATE TABLE FAMILIA (
    id_familia           INT IDENTITY(1,1) PRIMARY KEY,
    id_comunidad         INT          NOT NULL,
    nombres              VARCHAR(100) NOT NULL,
    apellidos            VARCHAR(100) NOT NULL,
    sexo                 CHAR(1)      NOT NULL CHECK (sexo IN ('F','M')),
    fecha_nacimiento     DATE         NOT NULL,
    nro_miembros         INT          NOT NULL CHECK (nro_miembros > 0),
    telefono             VARCHAR(20)  NULL,
    fecha_registro       DATE         NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    fecha_consentimiento DATE         NOT NULL,  -- consentimiento informado (ética de datos)
    CONSTRAINT FK_FAMILIA_COMUNIDAD FOREIGN KEY (id_comunidad)
        REFERENCES COMUNIDAD(id_comunidad)
);

CREATE TABLE PARCELA (
    id_parcela        INT IDENTITY(1,1) PRIMARY KEY,
    id_familia        INT          NOT NULL,
    id_proyecto       INT          NOT NULL,
    tipo              VARCHAR(20)  NOT NULL CHECK (tipo IN ('HUERTO','SAF')),
    superficie_m2     DECIMAL(8,2) NOT NULL CHECK (superficie_m2 > 0),
    tiene_riego       BIT          NOT NULL DEFAULT 0,
    fecha_instalacion DATE         NOT NULL,
    CONSTRAINT FK_PARCELA_FAMILIA  FOREIGN KEY (id_familia)  REFERENCES FAMILIA(id_familia),
    CONSTRAINT FK_PARCELA_PROYECTO FOREIGN KEY (id_proyecto) REFERENCES PROYECTO(id_proyecto)
);

CREATE TABLE INSUMO (
    id_insumo      INT IDENTITY(1,1) PRIMARY KEY,
    id_cultivo     INT           NULL,       -- solo plantines; el abono no tiene cultivo
    nombre         VARCHAR(100)  NOT NULL,
    tipo           VARCHAR(20)   NOT NULL CHECK (tipo IN ('PLANTIN','ABONO','BIOINSUMO')),
    unidad_medida  VARCHAR(20)   NOT NULL,
    costo_unitario DECIMAL(10,2) NOT NULL CHECK (costo_unitario >= 0),
    es_organico    BIT           NOT NULL DEFAULT 1,
    CONSTRAINT FK_INSUMO_CULTIVO FOREIGN KEY (id_cultivo) REFERENCES CULTIVO(id_cultivo)
);

CREATE TABLE ENTREGA (
    id_entrega INT IDENTITY(1,1) PRIMARY KEY,
    id_parcela INT           NOT NULL,
    id_insumo  INT           NOT NULL,
    id_usuario INT           NOT NULL,
    fecha      DATE          NOT NULL,
    cantidad   DECIMAL(10,2) NOT NULL CHECK (cantidad > 0),
    anulado    BIT           NOT NULL DEFAULT 0,
    CONSTRAINT CK_ENTREGA_fecha CHECK (fecha <= CAST(GETDATE() AS DATE)),
    CONSTRAINT FK_ENTREGA_PARCELA FOREIGN KEY (id_parcela) REFERENCES PARCELA(id_parcela),
    CONSTRAINT FK_ENTREGA_INSUMO  FOREIGN KEY (id_insumo)  REFERENCES INSUMO(id_insumo),
    CONSTRAINT FK_ENTREGA_USUARIO FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE VISITA (
    id_visita      INT IDENTITY(1,1) PRIMARY KEY,
    id_parcela     INT          NOT NULL,
    id_usuario     INT          NOT NULL,
    fecha          DATE         NOT NULL,
    estado_parcela VARCHAR(20)  NOT NULL CHECK (estado_parcela IN ('BUENO','REGULAR','MALO')),
    observacion    VARCHAR(255) NULL,
    anulado        BIT          NOT NULL DEFAULT 0,
    CONSTRAINT CK_VISITA_fecha CHECK (fecha <= CAST(GETDATE() AS DATE)),
    CONSTRAINT FK_VISITA_PARCELA FOREIGN KEY (id_parcela) REFERENCES PARCELA(id_parcela),
    CONSTRAINT FK_VISITA_USUARIO FOREIGN KEY (id_usuario) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE SEGUIMIENTO_CULTIVO (
    id_seguimiento INT IDENTITY(1,1) PRIMARY KEY,
    id_visita      INT           NOT NULL,
    id_cultivo     INT           NOT NULL,
    plantas_vivas  INT           NOT NULL CHECK (plantas_vivas >= 0),
    kg_cosechados  DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (kg_cosechados >= 0),
    CONSTRAINT UQ_SEGUIMIENTO UNIQUE (id_visita, id_cultivo),
    CONSTRAINT FK_SEG_VISITA  FOREIGN KEY (id_visita)  REFERENCES VISITA(id_visita),
    CONSTRAINT FK_SEG_CULTIVO FOREIGN KEY (id_cultivo) REFERENCES CULTIVO(id_cultivo)
);

CREATE TABLE ALERTA (
    id_alerta        INT IDENTITY(1,1) PRIMARY KEY,
    id_visita        INT          NOT NULL,
    supervivencia    DECIMAL(5,2) NOT NULL CHECK (supervivencia BETWEEN 0 AND 100),
    umbral_aplicado  DECIMAL(5,2) NOT NULL,
    nivel_riesgo     VARCHAR(10)  NOT NULL CHECK (nivel_riesgo IN ('MEDIO','CRITICO')),
    fecha_generacion DATETIME     NOT NULL DEFAULT GETDATE(),
    revisada         BIT          NOT NULL DEFAULT 0,
    CONSTRAINT FK_ALERTA_VISITA FOREIGN KEY (id_visita) REFERENCES VISITA(id_visita)
);

CREATE INDEX IX_ENTREGA_parcela ON ENTREGA (id_parcela, fecha);
CREATE INDEX IX_VISITA_parcela  ON VISITA  (id_parcela, fecha);
GO

-- Gobernanza: las entregas y visitas no se borran, solo se anulan (RNF-06)
CREATE TRIGGER trg_ENTREGA_sin_borrado ON ENTREGA
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50001, 'No se permite borrar entregas: use la anulación (anulado = 1).', 1;
END;
GO

CREATE TRIGGER trg_VISITA_sin_borrado ON VISITA
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    THROW 50002, 'No se permite borrar visitas: use la anulación (anulado = 1).', 1;
END;
GO
