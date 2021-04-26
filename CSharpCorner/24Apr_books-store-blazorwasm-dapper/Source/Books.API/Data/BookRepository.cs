using Books.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Books.API.Data
{

    public class BookRepository : IBookRepository
    {
        private readonly SettingsData _configuration;

        public BookRepository(SettingsData configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> AddBook(Book book)
        {
            using (var conn = new SqlConnection(_configuration.SqlServerConnection))
            {
                var parameters = new DynamicParameters();
                parameters.Add("PictureUrl", book.PictureUrl, DbType.String);
                parameters.Add("Title", book.Title, DbType.String);
                parameters.Add("Author", book.Author, DbType.String);
                parameters.Add("IsActive", book.IsActive, DbType.Boolean);
                parameters.Add("ISBN", book.ISBN, DbType.String);
                parameters.Add("Pages", book.Pages, DbType.Int32);

                // Stored procedure method
                await conn.ExecuteAsync("[dbo].[usp_add_book]", parameters,
                                commandType: CommandType.StoredProcedure)
                                .ConfigureAwait(false);
            }

            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> books;

            using (var conn = new SqlConnection(_configuration.SqlServerConnection))
            {
                books = await conn.QueryAsync<Book>("[dbo].[usp_get_all_books]",
                                commandType: CommandType.StoredProcedure)
                                .ConfigureAwait(false);
            }

            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            Book video = new();

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var conn = new SqlConnection(_configuration.SqlServerConnection))
            {
                video = await conn.QueryFirstOrDefaultAsync<Book>("[dbo].[usp_get_book_by_id]", parameters,
                                    commandType: CommandType.StoredProcedure)
                                    .ConfigureAwait(false);
            }

            return video;
        }
    }

}
