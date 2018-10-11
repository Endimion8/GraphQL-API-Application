using GraphQLAPI.Providers.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace GraphQLAPI.Providers
{
    public interface IBooksProvider
    {
        Task<IEnumerable<BookResponse>> GetBooksAsync();
        Task<BookResponse> GetBookByIdAsync(int bookId);
        Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(int authorId);
        Task<ILookup<int, BookResponse>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds);
        Task<BookResponse> CreateBookAsync(BookResponse book);
        BookResponse UpdateBook(int id, BookResponse book);
        Task<BookResponse> DeleteBookAsync(int bookId);
        Task<BookResponse> DeleteBookByNameAsync(string bookName);
    }
}
