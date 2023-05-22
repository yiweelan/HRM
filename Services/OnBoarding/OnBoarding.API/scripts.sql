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

CREATE TABLE [EmployeeStatusLookUps] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeStatusCode] nvarchar(64) NOT NULL,
    [EmployeeStatusDescription] nvarchar(1024) NOT NULL,
    CONSTRAINT [PK_EmployeeStatusLookUps] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Address] nvarchar(max) NULL,
    [Email] nvarchar(2048) NOT NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [MiddleName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [EndDate] datetime2 NULL,
    [HireDate] datetime2 NULL,
    [SSN] nvarchar(2048) NOT NULL,
    [EmployeeStatusId] int NOT NULL,
    [EmployeeStatusLookUpsId] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpsId] FOREIGN KEY ([EmployeeStatusLookUpsId]) REFERENCES [EmployeeStatusLookUps] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Employees_EmployeeStatusLookUpsId] ON [Employees] ([EmployeeStatusLookUpsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516160035_InitialMigrationOnBoard', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Employees] DROP CONSTRAINT [FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpsId];
GO

DROP INDEX [IX_Employees_EmployeeStatusLookUpsId] ON [Employees];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'EmployeeStatusLookUpsId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Employees] DROP COLUMN [EmployeeStatusLookUpsId];
GO

CREATE INDEX [IX_Employees_EmployeeStatusId] ON [Employees] ([EmployeeStatusId]);
GO

ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_EmployeeStatusLookUps_EmployeeStatusId] FOREIGN KEY ([EmployeeStatusId]) REFERENCES [EmployeeStatusLookUps] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516160406_OnBoardTableUpdate', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'MiddleName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Employees] ALTER COLUMN [MiddleName] nvarchar(50) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230516163251_OnBoardTableUpdateTwo', N'7.0.5');
GO

COMMIT;
GO

