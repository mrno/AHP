
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/31/2012 17:46:59
-- Generated from EDMX file: C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\sisexperto\sisexperto\Modelo2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gisiabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[alternativa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[alternativa];
GO
IF OBJECT_ID(N'[dbo].[comparacion_alternativa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[comparacion_alternativa];
GO
IF OBJECT_ID(N'[dbo].[comparacion_criterio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[comparacion_criterio];
GO
IF OBJECT_ID(N'[dbo].[criterio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[criterio];
GO
IF OBJECT_ID(N'[dbo].[experto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[experto];
GO
IF OBJECT_ID(N'[dbo].[experto_proyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[experto_proyecto];
GO
IF OBJECT_ID(N'[dbo].[proyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[proyecto];
GO
IF OBJECT_ID(N'[dbo].[ILSetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ILSetSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'alternativa'
CREATE TABLE [dbo].[alternativa] (
    [id_alternativa] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [descripcion] varchar(50)  NULL
);
GO

-- Creating table 'comparacion_alternativa'
CREATE TABLE [dbo].[comparacion_alternativa] (
    [id_comparacion] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [id_criterio] int  NOT NULL,
    [id_alternativa1] int  NOT NULL,
    [id_alternativa2] int  NOT NULL,
    [pos_fila] int  NOT NULL,
    [pos_columna] int  NOT NULL,
    [valor] float  NULL
);
GO

-- Creating table 'comparacion_criterio'
CREATE TABLE [dbo].[comparacion_criterio] (
    [id_comparacion] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [id_criterio1] int  NOT NULL,
    [id_criterio2] int  NOT NULL,
    [pos_fila] int  NOT NULL,
    [pos_columna] int  NOT NULL,
    [valor] float  NULL
);
GO

-- Creating table 'criterio'
CREATE TABLE [dbo].[criterio] (
    [id_criterio] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [descripcion] varchar(50)  NULL,
    [ILPonderacion] float  NOT NULL
);
GO

-- Creating table 'experto'
CREATE TABLE [dbo].[experto] (
    [id_experto] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [apellido] varchar(50)  NOT NULL,
    [nom_usuario] varchar(50)  NOT NULL,
    [clave] varchar(50)  NOT NULL
);
GO

-- Creating table 'experto_proyecto'
CREATE TABLE [dbo].[experto_proyecto] (
    [id_asignacion] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [ponderacion] float  NOT NULL,
    [ILPonderacion] float  NOT NULL,
    [valoracion_consistente] bit  NOT NULL
);
GO

-- Creating table 'proyecto'
CREATE TABLE [dbo].[proyecto] (
    [id_proyecto] int IDENTITY(1,1) NOT NULL,
    [id_creador] int  NOT NULL,
    [nombre] varchar(200)  NOT NULL,
    [objetivo] varchar(max)  NOT NULL
);
GO

-- Creating table 'ILSetSet'
CREATE TABLE [dbo].[ILSetSet] (
    [id_Model] int IDENTITY(1,1) NOT NULL,
    [id_Label] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [a] nvarchar(max)  NOT NULL,
    [b] nvarchar(max)  NOT NULL,
    [c] nvarchar(max)  NOT NULL,
    [id_proyecto] nvarchar(max)  NOT NULL,
    [id_asignacion] nvarchar(max)  NOT NULL,
    [valor] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_alternativa] in table 'alternativa'
ALTER TABLE [dbo].[alternativa]
ADD CONSTRAINT [PK_alternativa]
    PRIMARY KEY CLUSTERED ([id_alternativa] ASC);
GO

-- Creating primary key on [id_comparacion] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [PK_comparacion_alternativa]
    PRIMARY KEY CLUSTERED ([id_comparacion] ASC);
GO

-- Creating primary key on [id_comparacion] in table 'comparacion_criterio'
ALTER TABLE [dbo].[comparacion_criterio]
ADD CONSTRAINT [PK_comparacion_criterio]
    PRIMARY KEY CLUSTERED ([id_comparacion] ASC);
GO

-- Creating primary key on [id_criterio] in table 'criterio'
ALTER TABLE [dbo].[criterio]
ADD CONSTRAINT [PK_criterio]
    PRIMARY KEY CLUSTERED ([id_criterio] ASC);
GO

-- Creating primary key on [id_experto] in table 'experto'
ALTER TABLE [dbo].[experto]
ADD CONSTRAINT [PK_experto]
    PRIMARY KEY CLUSTERED ([id_experto] ASC);
GO

-- Creating primary key on [id_asignacion] in table 'experto_proyecto'
ALTER TABLE [dbo].[experto_proyecto]
ADD CONSTRAINT [PK_experto_proyecto]
    PRIMARY KEY CLUSTERED ([id_asignacion] ASC);
GO

-- Creating primary key on [id_proyecto] in table 'proyecto'
ALTER TABLE [dbo].[proyecto]
ADD CONSTRAINT [PK_proyecto]
    PRIMARY KEY CLUSTERED ([id_proyecto] ASC);
GO

-- Creating primary key on [id_Model] in table 'ILSetSet'
ALTER TABLE [dbo].[ILSetSet]
ADD CONSTRAINT [PK_ILSetSet]
    PRIMARY KEY CLUSTERED ([id_Model] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------