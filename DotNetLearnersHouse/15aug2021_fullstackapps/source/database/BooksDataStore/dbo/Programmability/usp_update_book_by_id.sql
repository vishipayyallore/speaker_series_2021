CREATE PROCEDURE [dbo].[usp_update_book_by_id]
	@Id int,
	@PictureUrl VARCHAR(100),
	@Title VARCHAR(100),
	@Author VARCHAR(100),
	@IsActive BIT,
	@ISBN VARCHAR(50),
	@Pages NUMERIC(6,0)

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Books
		SET PictureUrl = @PictureUrl, Title = @Title, Author = @Author
		, IsActive = @IsActive, ISBN = @ISBN, Pages = @Pages
	WHERE
		Id = @Id;

	SELECT @@ROWCOUNT;

END
