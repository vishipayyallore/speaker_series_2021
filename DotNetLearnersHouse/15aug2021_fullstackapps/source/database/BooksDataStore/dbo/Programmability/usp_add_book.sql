CREATE PROCEDURE [dbo].[usp_add_book]
	@PictureUrl VARCHAR(100),
	@Title VARCHAR(100),
	@Author VARCHAR(100),
	@IsActive BIT,
	@ISBN VARCHAR(50),
	@Pages NUMERIC(6,0),
    @Id INT OUTPUT

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Books
		(PictureUrl, Title, Author, IsActive, ISBN, Pages)
	VALUES
		(@PictureUrl, @Title, @Author, @IsActive, @ISBN, @Pages);

	SET @Id = SCOPE_IDENTITY() 

END
