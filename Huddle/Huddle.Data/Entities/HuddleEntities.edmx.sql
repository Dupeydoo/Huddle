
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/25/2017 12:45:28
-- Generated from EDMX file: C:\Users\james\Source\Repos\Huddle\Huddle\Huddle.Data\Entities\HuddleEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Huddle];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Post_Thread]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_Post_Thread];
GO
IF OBJECT_ID(N'[dbo].[FK_Thread_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Thread] DROP CONSTRAINT [FK_Thread_Category];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[Thread]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Thread];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(60)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NOT NULL,
    [Description] nvarchar(200)  NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ThreadId] int  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [PostMessage] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Threads'
CREATE TABLE [dbo].[Threads] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(60)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [CreatedBy] nvarchar(50)  NOT NULL,
    [ModifiedBy] nvarchar(50)  NOT NULL,
    [Views] int  NOT NULL,
    [IsSticky] bit  NOT NULL,
    [CategoryId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Threads'
ALTER TABLE [dbo].[Threads]
ADD CONSTRAINT [PK_Threads]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'Threads'
ALTER TABLE [dbo].[Threads]
ADD CONSTRAINT [FK_Thread_Category]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Thread_Category'
CREATE INDEX [IX_FK_Thread_Category]
ON [dbo].[Threads]
    ([CategoryId]);
GO

-- Creating foreign key on [ThreadId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Post_Thread]
    FOREIGN KEY ([ThreadId])
    REFERENCES [dbo].[Threads]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Post_Thread'
CREATE INDEX [IX_FK_Post_Thread]
ON [dbo].[Posts]
    ([ThreadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------