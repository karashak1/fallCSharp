
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/02/2013 21:34:06
-- Generated from EDMX file: C:\Users\Kevin\Documents\GitHub\fallCSharp\DataAccess\ContactModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CSharp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KeywordsKeywords]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Keywords] DROP CONSTRAINT [FK_KeywordsKeywords];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactsKeywords]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_ContactsKeywords];
GO
IF OBJECT_ID(N'[dbo].[FK_ContactContractMethod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactMethods] DROP CONSTRAINT [FK_ContactContractMethod];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractMethodKeyword]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContactMethods] DROP CONSTRAINT [FK_ContractMethodKeyword];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Keywords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Keywords];
GO
IF OBJECT_ID(N'[dbo].[ContactMethods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactMethods];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [KeywordsId] int  NOT NULL
);
GO

-- Creating table 'Keywords'
CREATE TABLE [dbo].[Keywords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [KeywordsId] int  NOT NULL
);
GO

-- Creating table 'ContactMethods'
CREATE TABLE [dbo].[ContactMethods] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [ContactId] int  NOT NULL,
    [KeywordID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Keywords'
ALTER TABLE [dbo].[Keywords]
ADD CONSTRAINT [PK_Keywords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactMethods'
ALTER TABLE [dbo].[ContactMethods]
ADD CONSTRAINT [PK_ContactMethods]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KeywordsId] in table 'Keywords'
ALTER TABLE [dbo].[Keywords]
ADD CONSTRAINT [FK_KeywordsKeywords]
    FOREIGN KEY ([KeywordsId])
    REFERENCES [dbo].[Keywords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KeywordsKeywords'
CREATE INDEX [IX_FK_KeywordsKeywords]
ON [dbo].[Keywords]
    ([KeywordsId]);
GO

-- Creating foreign key on [KeywordsId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_ContactsKeywords]
    FOREIGN KEY ([KeywordsId])
    REFERENCES [dbo].[Keywords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactsKeywords'
CREATE INDEX [IX_FK_ContactsKeywords]
ON [dbo].[Contacts]
    ([KeywordsId]);
GO

-- Creating foreign key on [ContactId] in table 'ContactMethods'
ALTER TABLE [dbo].[ContactMethods]
ADD CONSTRAINT [FK_ContactContractMethod]
    FOREIGN KEY ([ContactId])
    REFERENCES [dbo].[Contacts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactContractMethod'
CREATE INDEX [IX_FK_ContactContractMethod]
ON [dbo].[ContactMethods]
    ([ContactId]);
GO

-- Creating foreign key on [KeywordID] in table 'ContactMethods'
ALTER TABLE [dbo].[ContactMethods]
ADD CONSTRAINT [FK_ContractMethodKeyword]
    FOREIGN KEY ([KeywordID])
    REFERENCES [dbo].[Keywords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractMethodKeyword'
CREATE INDEX [IX_FK_ContractMethodKeyword]
ON [dbo].[ContactMethods]
    ([KeywordID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------