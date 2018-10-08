using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Library.Dal.Models;

namespace GraphQLAPI.Library.Lib
{
    public interface ILibraryService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
		Task<Author> GetAuthorByIdAsync(int autorId);
		Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token);
        Task<Author> CreateAuthorAsync(Author author);
        Author UpdateAuthor(int id, Author author);
        Task<Author> DeleteAuthorAsync(int autorId);
        Task<Author> DeleteAuthorByNameAsync(string authorName);

		Task<IEnumerable<Book>> GetBooksAsync();
		Task<Book> GetBookByIdAsync(int bookId);
        Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token);
		Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
		Task<ILookup<int, Book>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds);
		Task<Book> CreateBookAsync(Book book);
		Book UpdateBook(int id, Book book);
        Task<Book> DeleteBookAsync(int bookId);
        Task<Book> DeleteBookByNameAsync(string bookName);

    }
}