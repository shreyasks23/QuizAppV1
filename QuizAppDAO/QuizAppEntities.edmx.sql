
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2021 10:31:39
-- Generated from EDMX file: F:\Workspace\QuizAppV1\QuizAppV1\QuizAppDAO\QuizAppEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuizApp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Assessmen__Asses__22AA2996]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentQuestions] DROP CONSTRAINT [FK__Assessmen__Asses__22AA2996];
GO
IF OBJECT_ID(N'[dbo].[FK__Assessmen__Asses__276EDEB3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentUsers] DROP CONSTRAINT [FK__Assessmen__Asses__276EDEB3];
GO
IF OBJECT_ID(N'[dbo].[FK__Assessmen__Quest__21B6055D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentQuestions] DROP CONSTRAINT [FK__Assessmen__Quest__21B6055D];
GO
IF OBJECT_ID(N'[dbo].[FK__Assessmen__UserI__267ABA7A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentUsers] DROP CONSTRAINT [FK__Assessmen__UserI__267ABA7A];
GO
IF OBJECT_ID(N'[dbo].[FK__Choices__Questio__164452B1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Choices] DROP CONSTRAINT [FK__Choices__Questio__164452B1];
GO
IF OBJECT_ID(N'[dbo].[FK__results__UserID__1B0907CE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[results] DROP CONSTRAINT [FK__results__UserID__1B0907CE];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AssessmentQuestions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssessmentQuestions];
GO
IF OBJECT_ID(N'[dbo].[Assessments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assessments];
GO
IF OBJECT_ID(N'[dbo].[AssessmentUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssessmentUsers];
GO
IF OBJECT_ID(N'[dbo].[Choices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Choices];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[results]', 'U') IS NOT NULL
    DROP TABLE [dbo].[results];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AssessmentQuestions'
CREATE TABLE [dbo].[AssessmentQuestions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [QuestionID] int  NULL,
    [AssessmentID] int  NULL,
    [Isdeleted] bit  NULL
);
GO

-- Creating table 'Assessments'
CREATE TABLE [dbo].[Assessments] (
    [AssessmentID] int IDENTITY(1,1) NOT NULL,
    [AssessmentName] nvarchar(100)  NOT NULL,
    [MaxMarks] float  NOT NULL,
    [Isdeleted] bit  NULL
);
GO

-- Creating table 'AssessmentUsers'
CREATE TABLE [dbo].[AssessmentUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [AssessmentID] int  NULL,
    [IsAttempted] bit  NULL,
    [Isdeleted] bit  NULL
);
GO

-- Creating table 'Choices'
CREATE TABLE [dbo].[Choices] (
    [ChoiceID] int IDENTITY(1,1) NOT NULL,
    [ChoiceText] nvarchar(100)  NOT NULL,
    [QuestionID] int  NULL,
    [Isdeleted] bit  NULL,
    [IsCorrect] bit  NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [QuestionID] int IDENTITY(1,1) NOT NULL,
    [QuestionText] nvarchar(500)  NOT NULL,
    [MaxMarks] float  NOT NULL,
    [Isdeleted] bit  NULL
);
GO

-- Creating table 'results'
CREATE TABLE [dbo].[results] (
    [ResultID] int IDENTITY(1,1) NOT NULL,
    [TotalMarks] float  NOT NULL,
    [MarksScored] float  NOT NULL,
    [UserID] int  NULL,
    [Isdeleted] bit  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(500)  NOT NULL,
    [Isdeleted] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AssessmentQuestions'
ALTER TABLE [dbo].[AssessmentQuestions]
ADD CONSTRAINT [PK_AssessmentQuestions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AssessmentID] in table 'Assessments'
ALTER TABLE [dbo].[Assessments]
ADD CONSTRAINT [PK_Assessments]
    PRIMARY KEY CLUSTERED ([AssessmentID] ASC);
GO

-- Creating primary key on [Id] in table 'AssessmentUsers'
ALTER TABLE [dbo].[AssessmentUsers]
ADD CONSTRAINT [PK_AssessmentUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ChoiceID] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [PK_Choices]
    PRIMARY KEY CLUSTERED ([ChoiceID] ASC);
GO

-- Creating primary key on [QuestionID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([QuestionID] ASC);
GO

-- Creating primary key on [ResultID] in table 'results'
ALTER TABLE [dbo].[results]
ADD CONSTRAINT [PK_results]
    PRIMARY KEY CLUSTERED ([ResultID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AssessmentID] in table 'AssessmentQuestions'
ALTER TABLE [dbo].[AssessmentQuestions]
ADD CONSTRAINT [FK__Assessmen__Asses__2B3F6F97]
    FOREIGN KEY ([AssessmentID])
    REFERENCES [dbo].[Assessments]
        ([AssessmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Assessmen__Asses__2B3F6F97'
CREATE INDEX [IX_FK__Assessmen__Asses__2B3F6F97]
ON [dbo].[AssessmentQuestions]
    ([AssessmentID]);
GO

-- Creating foreign key on [QuestionID] in table 'AssessmentQuestions'
ALTER TABLE [dbo].[AssessmentQuestions]
ADD CONSTRAINT [FK__Assessmen__Quest__2A4B4B5E]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Questions]
        ([QuestionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Assessmen__Quest__2A4B4B5E'
CREATE INDEX [IX_FK__Assessmen__Quest__2A4B4B5E]
ON [dbo].[AssessmentQuestions]
    ([QuestionID]);
GO

-- Creating foreign key on [AssessmentID] in table 'AssessmentUsers'
ALTER TABLE [dbo].[AssessmentUsers]
ADD CONSTRAINT [FK__Assessmen__Asses__37A5467C]
    FOREIGN KEY ([AssessmentID])
    REFERENCES [dbo].[Assessments]
        ([AssessmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Assessmen__Asses__37A5467C'
CREATE INDEX [IX_FK__Assessmen__Asses__37A5467C]
ON [dbo].[AssessmentUsers]
    ([AssessmentID]);
GO

-- Creating foreign key on [UserID] in table 'AssessmentUsers'
ALTER TABLE [dbo].[AssessmentUsers]
ADD CONSTRAINT [FK__Assessmen__UserI__36B12243]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Assessmen__UserI__36B12243'
CREATE INDEX [IX_FK__Assessmen__UserI__36B12243]
ON [dbo].[AssessmentUsers]
    ([UserID]);
GO

-- Creating foreign key on [QuestionID] in table 'Choices'
ALTER TABLE [dbo].[Choices]
ADD CONSTRAINT [FK_Choices_Questions]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Questions]
        ([QuestionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Choices_Questions'
CREATE INDEX [IX_FK_Choices_Questions]
ON [dbo].[Choices]
    ([QuestionID]);
GO

-- Creating foreign key on [UserID] in table 'results'
ALTER TABLE [dbo].[results]
ADD CONSTRAINT [FK__results__UserID__239E4DCF]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__results__UserID__239E4DCF'
CREATE INDEX [IX_FK__results__UserID__239E4DCF]
ON [dbo].[results]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------