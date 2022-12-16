
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2022 11:37:00
-- Generated from EDMX file: C:\Users\Admin Stagiaire\Documents\C#\FormationEntityFramework\DataBaseFirstDemo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [codefirstdemo_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Clients_dbo_Villes_Ville_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_dbo_Clients_dbo_Villes_Ville_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Villes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Villes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [Prenom] nvarchar(max)  NULL,
    [Ville_Id] int  NULL
);
GO

-- Creating table 'Villes'
CREATE TABLE [dbo].[Villes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NomVille] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Villes'
ALTER TABLE [dbo].[Villes]
ADD CONSTRAINT [PK_Villes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Ville_Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_dbo_Clients_dbo_Villes_Ville_Id]
    FOREIGN KEY ([Ville_Id])
    REFERENCES [dbo].[Villes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Clients_dbo_Villes_Ville_Id'
CREATE INDEX [IX_FK_dbo_Clients_dbo_Villes_Ville_Id]
ON [dbo].[Clients]
    ([Ville_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------