﻿/*
Deployment script for UrlShortener

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "UrlShortener"
:setvar DefaultFilePrefix "UrlShortener"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 9ce4c028-142f-41ea-be47-461c776826e7 is skipped, element [dbo].[Url].[Url] (SqlSimpleColumn) will not be renamed to OriginalUrl';


GO
PRINT N'Creating [dbo].[GetShortenUrl]...';


GO
CREATE PROCEDURE [dbo].[GetShortenUrl]
	@ShortenUrl varchar(50) 
AS
BEGIN
	Set nocount on 
	
	SELECT OriginalUrl from Url Where ShortenUrl=@ShortenUrl

END
GO
PRINT N'Creating [dbo].[InsertShortenUrl]...';


GO
CREATE PROCEDURE [dbo].[InsertShortenUrl]
	@OriginalUrl nvarchar(2083),
	@ShortenUrl varchar(50) ,
	@UserId varchar(128) Null
AS
BEGIN
	Set nocount on 
	Declare @Id uniqueIdentifier 
	set @Id=NEWID()

	INSERT INTO Url(Id,ShortenUrl,[OriginalUrl],[UserId]) VALUES(@Id,@ShortenUrl,@OriginalUrl,@UserId)

	Select @ShortenUrl

END
GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9ce4c028-142f-41ea-be47-461c776826e7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9ce4c028-142f-41ea-be47-461c776826e7')

GO

GO
PRINT N'Update complete.';


GO
