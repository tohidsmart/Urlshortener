CREATE PROCEDURE [dbo].[GetShortenUrl]
	@ShortenUrl varchar(50) 
AS
BEGIN
	Set nocount on 
	
	SELECT OriginalUrl from Url Where ShortenUrl=@ShortenUrl

END
