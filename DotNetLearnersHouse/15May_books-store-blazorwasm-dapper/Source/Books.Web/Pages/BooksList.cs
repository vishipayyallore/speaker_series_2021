using Books.Data;
using Books.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Web.Pages
{
    public partial class BooksList
    {
        [Inject]
        private IBookDataService BookDataService { get; set; }

        public IEnumerable<Book> Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = await BookDataService.GetAllBooks();
        }
    }
}
