using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Response;

namespace GraphQLAPI.Library.Lib
{
    public interface ILibraryService
    {
        Task<IEnumerable<AuthorResponseLib>> GetAuthorsAsync();
		Task<AuthorResponseLib> GetAuthorByIdAsync(int autorId);
		Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token);
        Task<AuthorResponseLib> CreateAuthorAsync(AuthorResponseLib author);
        AuthorResponseLib UpdateAuthor(AuthorResponseLib author);
        Task<AuthorResponseLib> DeleteAuthorAsync(int autorId);
        Task<AuthorResponseLib> DeleteAuthorByNameAsync(string authorName);

		Task<IEnumerable<BookResponseLib>> GetBooksAsync();
		Task<BookResponseLib> GetBookByIdAsync(int bookId);
        Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token);
		Task<IEnumerable<BookResponseLib>> GetBooksByAuthorIdAsync(int authorId);
		Task<List<BookResponseLib>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds);
		Task<BookResponseLib> CreateBookAsync(BookResponseLib book);
        BookResponseLib UpdateBook(BookResponseLib book);
        Task<BookResponseLib> DeleteBookAsync(int bookId);
        Task<BookResponseLib> DeleteBookByNameAsync(string bookName);

    }
}