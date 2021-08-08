CREATE PROCEDURE [dbo].[usp_get_book_by_id]
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		Id, PictureUrl, Title, Author, IsActive, ISBN, Pages
	FROM
		Books
	WHERE
		Id = @Id;

END
