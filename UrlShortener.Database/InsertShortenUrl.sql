Create PROCEDURE [dbo].[InsertShortenUrl]
	@OriginalUrl nvarchar(2083),
	@ShortenUrl varchar(50) ,
	@UserId varchar(128)=Null
AS
BEGIN
	Set nocount on 
	Declare @Id uniqueIdentifier 
	set @Id=NEWID()

	INSERT INTO Url(Id,ShortenUrl,[OriginalUrl],[UserId]) VALUES(@Id,@ShortenUrl,@OriginalUrl,@UserId)

	Select @ShortenUrl

END
