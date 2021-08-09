using BooksStore.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksStore.Core.Interfaces
{

    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);
    }

}
