namespace BooksStore.Data
{

    public class Book
    {
        public int Id { get; set; }

        public string PictureUrl { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string ISBN { get; set; } = string.Empty;

        public int Pages { get; set; }
    }

}
