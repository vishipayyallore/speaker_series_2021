CREATE PROCEDURE [dbo].[usp_get_all_books]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		Id, PictureUrl, Title, Author, IsActive, ISBN, Pages
	From
		Books;

END
