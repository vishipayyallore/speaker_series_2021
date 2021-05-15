using Books.Data;
using Books.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Books.Web.Pages
{

    public partial class AddBook
    {
        [Inject]
        private IBookDataService BookDataService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private Random _random = new Random();

        public Book book { get; set; } = new Book();

        protected async Task SaveBook()
        {
            book.PictureUrl = $"/images/books/Book{_random.Next(1, 10)}.jpg";

            await BookDataService.AddBook(book);

            NavigationManager.NavigateTo("bookslist");
        }

        protected async Task Home()
        {
            NavigationManager.NavigateTo("bookslist");
        }

    }

}
