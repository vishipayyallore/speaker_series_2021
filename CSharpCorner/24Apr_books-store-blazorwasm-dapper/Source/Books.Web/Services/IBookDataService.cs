using Books.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Web.Services
{
    public interface IBookDataService
    {
        Task<bool> AddBook(Book book);

        Task<IEnumerable<Book>> GetAllBooks();
    }

}
