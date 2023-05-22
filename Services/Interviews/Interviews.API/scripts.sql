IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Interviewers] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Interviewers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Interviews] (
    [id] int NOT NULL IDENTITY,
    [BeginTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [CandidateEmail] nvarchar(max) NOT NULL,
    [CandidateFirstName] nvarchar(50) NOT NULL,
    [CandidateLastName] nvarchar(50) NOT NULL,
    [CandidateIdentityId] uniqueidentifier NOT NULL,
    [Feedback] nvarchar(max) NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY ([id])
);
GO

CREATE TABLE [interviewTypeLookUps] (
    [Id] int NOT NULL IDENTITY,
    [InterviewTypeCode] nvarchar(50) NOT NULL,
    [InterviewTypeDescription] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_interviewTypeLookUps] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516213536_InitialMigrationInterview', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Interviews] ADD [InterviewTypeId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Interviews] ADD [InterviewerId] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Interviews] ADD [Passed] bit NULL;
GO

ALTER TABLE [Interviews] ADD [Rating] int NULL;
GO

ALTER TABLE [Interviews] ADD [SubmissionId] int NOT NULL DEFAULT 0;
GO

CREATE INDEX [IX_Interviews_InterviewerId] ON [Interviews] ([InterviewerId]);
GO

CREATE INDEX [IX_Interviews_InterviewTypeId] ON [Interviews] ([InterviewTypeId]);
GO

ALTER TABLE [Interviews] ADD CONSTRAINT [FK_Interviews_Interviewers_InterviewerId] FOREIGN KEY ([InterviewerId]) REFERENCES [Interviewers] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Interviews] ADD CONSTRAINT [FK_Interviews_interviewTypeLookUps_InterviewTypeId] FOREIGN KEY ([InterviewTypeId]) REFERENCES [interviewTypeLookUps] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516214100_InterviewTableUpdate', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Interviews].[id]', N'Id', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516235102_InterviewTableUpdateTwo', N'7.0.5');
GO

COMMIT;
GO

