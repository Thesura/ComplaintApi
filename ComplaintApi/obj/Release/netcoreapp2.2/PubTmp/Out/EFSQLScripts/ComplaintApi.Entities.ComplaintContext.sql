IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [CompanyMasters] (
        [CompanyID] nvarchar(100) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [CompanyName] nvarchar(150) NULL,
        [Email] nvarchar(50) NULL,
        CONSTRAINT [PK_CompanyMasters] PRIMARY KEY ([CompanyID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [ComplainsHistories] (
        [HistoryID] nvarchar(100) NOT NULL,
        [ComplainID] nvarchar(50) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [Description] nvarchar(150) NULL,
        [Status] nvarchar(50) NULL,
        [UpdateAt] datetime2 NOT NULL,
        [UpdatedBy] nvarchar(100) NULL,
        CONSTRAINT [PK_ComplainsHistories] PRIMARY KEY ([HistoryID], [ComplainID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [ComplainsMasters] (
        [CompanyID] nvarchar(100) NOT NULL,
        [ModuleID] nvarchar(50) NOT NULL,
        [EmpID] nvarchar(50) NOT NULL,
        [PriorityID] nvarchar(50) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [Description] nvarchar(150) NULL,
        [Status] nvarchar(50) NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_ComplainsMasters] PRIMARY KEY ([CompanyID], [ModuleID], [EmpID], [PriorityID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [ModuleMasters] (
        [ModuleID] nvarchar(50) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [ModuleName] nvarchar(50) NULL,
        CONSTRAINT [PK_ModuleMasters] PRIMARY KEY ([ModuleID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [PriorityMasters] (
        [PriorityID] nvarchar(100) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [Description] nvarchar(100) NULL,
        CONSTRAINT [PK_PriorityMasters] PRIMARY KEY ([PriorityID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [UserCompanies] (
        [EmpID] nvarchar(50) NOT NULL,
        [CompanyID] nvarchar(100) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_UserCompanies] PRIMARY KEY ([EmpID], [CompanyID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [UserMasters] (
        [EmpID] nvarchar(50) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        [Name] nvarchar(50) NULL,
        [Email] nvarchar(40) NULL,
        [Password] nvarchar(20) NULL,
        [IsAdmin] int NOT NULL,
        CONSTRAINT [PK_UserMasters] PRIMARY KEY ([EmpID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    CREATE TABLE [UserModules] (
        [EmpID] nvarchar(50) NOT NULL,
        [ModuleID] nvarchar(50) NOT NULL,
        [COMPCODE] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_UserModules] PRIMARY KEY ([EmpID], [ModuleID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190921054106_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190921054106_InitialMigration', N'2.2.6-servicing-10079');
END;

GO

