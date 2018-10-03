using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Models;

namespace GraphQLAPI.Store
{
    public interface IDataStore
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
		Task<Author> GetAuthorByIdAsync(int autorId);
		Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token);
        Task<Author> CreateAuthorAsync(Author author);

		Task<IEnumerable<Book>> GetBooksAsync();
		Task<Book> GetBookByIdAsync(int bookId);
        Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token);
		Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
		Task<ILookup<int, Book>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds);
		Task<Book> CreateBookAsync(Book book);      

	}
}