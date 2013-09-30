
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/30/2013 17:02:53
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Type_Id] int  NOT NULL
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

-- Creating foreign key on [Type_Id] in table 'ContactMethods'
ALTER TABLE [dbo].[ContactMethods]
ADD CONSTRAINT [FK_ContractMethodKeyword]
    FOREIGN KEY ([Type_Id])
    REFERENCES [dbo].[Keywords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractMethodKeyword'
CREATE INDEX [IX_FK_ContractMethodKeyword]
ON [dbo].[ContactMethods]
    ([Type_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------