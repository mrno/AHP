
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/04/2012 18:57:28
-- Generated from EDMX file: C:\Documents and Settings\gisiaa\Mis documentos\GitHub\AHP\sisexperto\sisexperto\modelobase.edmx
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
IF OBJECT_ID(N'[gisiabaseModelStoreContainer].[comparacion_alternativa]', 'U') IS NOT NULL
    DROP TABLE [gisiabaseModelStoreContainer].[comparacion_alternativa];
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
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [id_criterio] int  NOT NULL,
    [id_alternativa1] int  NOT NULL,
    [id_alternativa2] int  NOT NULL,
    [valor] float  NULL
);
GO

-- Creating table 'comparacion_criterio'
CREATE TABLE [dbo].[comparacion_criterio] (
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [id_criterio1] int  NOT NULL,
    [id_criterio2] int  NOT NULL,
    [valor] float  NULL,
    [id_comparacion] int IDENTITY(1,1) NOT NULL,
    [pos_fila] int  NOT NULL,
    [pos_columna] int  NOT NULL
);
GO

-- Creating table 'criterio'
CREATE TABLE [dbo].[criterio] (
    [id_criterio] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [descripcion] varchar(50)  NULL
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
    [id_proyecto] int  NOT NULL,
    [id_experto] int  NOT NULL,
    [ponderacion] float  NULL,
    [id_asignacion] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'proyecto'
CREATE TABLE [dbo].[proyecto] (
    [id_proyecto] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [objetivo] varchar(50)  NULL
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

-- Creating primary key on [id_proyecto], [id_experto], [id_criterio], [id_alternativa1], [id_alternativa2] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [PK_comparacion_alternativa]
    PRIMARY KEY CLUSTERED ([id_proyecto], [id_experto], [id_criterio], [id_alternativa1], [id_alternativa2] ASC);
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_alternativa1] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [FK_alternativacomparacion_alternativa]
    FOREIGN KEY ([id_alternativa1])
    REFERENCES [dbo].[alternativa]
        ([id_alternativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alternativacomparacion_alternativa'
CREATE INDEX [IX_FK_alternativacomparacion_alternativa]
ON [dbo].[comparacion_alternativa]
    ([id_alternativa1]);
GO

-- Creating foreign key on [id_alternativa2] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [FK_alternativacomparacion_alternativa1]
    FOREIGN KEY ([id_alternativa2])
    REFERENCES [dbo].[alternativa]
        ([id_alternativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_alternativacomparacion_alternativa1'
CREATE INDEX [IX_FK_alternativacomparacion_alternativa1]
ON [dbo].[comparacion_alternativa]
    ([id_alternativa2]);
GO

-- Creating foreign key on [id_proyecto] in table 'alternativa'
ALTER TABLE [dbo].[alternativa]
ADD CONSTRAINT [FK_proyectoalternativa]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[proyecto]
        ([id_proyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_proyectoalternativa'
CREATE INDEX [IX_FK_proyectoalternativa]
ON [dbo].[alternativa]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_criterio] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [FK_criteriocomparacion_alternativa]
    FOREIGN KEY ([id_criterio])
    REFERENCES [dbo].[criterio]
        ([id_criterio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_criteriocomparacion_alternativa'
CREATE INDEX [IX_FK_criteriocomparacion_alternativa]
ON [dbo].[comparacion_alternativa]
    ([id_criterio]);
GO

-- Creating foreign key on [id_experto] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [FK_expertocomparacion_alternativa]
    FOREIGN KEY ([id_experto])
    REFERENCES [dbo].[experto]
        ([id_experto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_expertocomparacion_alternativa'
CREATE INDEX [IX_FK_expertocomparacion_alternativa]
ON [dbo].[comparacion_alternativa]
    ([id_experto]);
GO

-- Creating foreign key on [id_proyecto] in table 'comparacion_alternativa'
ALTER TABLE [dbo].[comparacion_alternativa]
ADD CONSTRAINT [FK_proyectocomparacion_alternativa]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[proyecto]
        ([id_proyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_criterio1] in table 'comparacion_criterio'
ALTER TABLE [dbo].[comparacion_criterio]
ADD CONSTRAINT [FK_criteriocomparacion_criterio]
    FOREIGN KEY ([id_criterio1])
    REFERENCES [dbo].[criterio]
        ([id_criterio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_criteriocomparacion_criterio'
CREATE INDEX [IX_FK_criteriocomparacion_criterio]
ON [dbo].[comparacion_criterio]
    ([id_criterio1]);
GO

-- Creating foreign key on [id_criterio2] in table 'comparacion_criterio'
ALTER TABLE [dbo].[comparacion_criterio]
ADD CONSTRAINT [FK_criteriocomparacion_criterio1]
    FOREIGN KEY ([id_criterio2])
    REFERENCES [dbo].[criterio]
        ([id_criterio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_criteriocomparacion_criterio1'
CREATE INDEX [IX_FK_criteriocomparacion_criterio1]
ON [dbo].[comparacion_criterio]
    ([id_criterio2]);
GO

-- Creating foreign key on [id_experto] in table 'comparacion_criterio'
ALTER TABLE [dbo].[comparacion_criterio]
ADD CONSTRAINT [FK_expertocomparacion_criterio]
    FOREIGN KEY ([id_experto])
    REFERENCES [dbo].[experto]
        ([id_experto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_expertocomparacion_criterio'
CREATE INDEX [IX_FK_expertocomparacion_criterio]
ON [dbo].[comparacion_criterio]
    ([id_experto]);
GO

-- Creating foreign key on [id_proyecto] in table 'comparacion_criterio'
ALTER TABLE [dbo].[comparacion_criterio]
ADD CONSTRAINT [FK_proyectocomparacion_criterio]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[proyecto]
        ([id_proyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_proyectocomparacion_criterio'
CREATE INDEX [IX_FK_proyectocomparacion_criterio]
ON [dbo].[comparacion_criterio]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_proyecto] in table 'criterio'
ALTER TABLE [dbo].[criterio]
ADD CONSTRAINT [FK_proyectocriterio]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[proyecto]
        ([id_proyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_proyectocriterio'
CREATE INDEX [IX_FK_proyectocriterio]
ON [dbo].[criterio]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_experto] in table 'experto_proyecto'
ALTER TABLE [dbo].[experto_proyecto]
ADD CONSTRAINT [FK_expertoexperto_proyecto]
    FOREIGN KEY ([id_experto])
    REFERENCES [dbo].[experto]
        ([id_experto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_expertoexperto_proyecto'
CREATE INDEX [IX_FK_expertoexperto_proyecto]
ON [dbo].[experto_proyecto]
    ([id_experto]);
GO

-- Creating foreign key on [id_proyecto] in table 'experto_proyecto'
ALTER TABLE [dbo].[experto_proyecto]
ADD CONSTRAINT [FK_proyectoexperto_proyecto]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[proyecto]
        ([id_proyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_proyectoexperto_proyecto'
CREATE INDEX [IX_FK_proyectoexperto_proyecto]
ON [dbo].[experto_proyecto]
    ([id_proyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------