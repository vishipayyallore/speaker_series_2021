CREATE PROCEDURE [dbo].[usp_delete_book_by_id]
	@Id int

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE 
	FROM
		Books
	WHERE
		Id = @Id;

	SELECT @@ROWCOUNT;

END
