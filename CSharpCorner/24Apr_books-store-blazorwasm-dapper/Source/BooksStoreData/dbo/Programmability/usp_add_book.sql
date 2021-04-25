CREATE PROCEDURE [dbo].[usp_add_book]
	@PictureUrl VARCHAR(100),
	@Title VARCHAR(100),
	@Author VARCHAR(100),
	@IsActive BIT,
	@ISBN VARCHAR(50),
	@Pages NUMERIC(6,0)

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Books
		(PictureUrl, Title, Author, IsActive, ISBN, Pages)
	VALUES
		(@PictureUrl, @Title, @Author, @IsActive, @ISBN, @Pages);

	SELECT SCOPE_IDENTITY();

END
