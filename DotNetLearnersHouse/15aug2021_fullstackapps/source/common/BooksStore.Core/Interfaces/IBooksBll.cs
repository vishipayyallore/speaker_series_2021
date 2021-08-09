using BooksStore.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksStore.Core.Interfaces
{

    public interface IBooksBll
    {
        Task<Book> AddBook(Book video);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);
    }

}
