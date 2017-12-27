CREATE TABLE [dbo].[Url]
(
	[Id] uniqueidentifier NOT NULL,
	[ShortenUrl] varchar(50) NOT NULL PRIMARY KEY,
	[OriginalUrl] nvarchar(2083) NOT NULL, 
    [UserId] NVARCHAR(128) NULL,
	
)
