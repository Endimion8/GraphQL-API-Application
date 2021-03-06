using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Request;
using GraphQLAPI.Library.Lib.Response;
using Library.Lib.Request;
using Library.Lib.Response;

namespace GraphQLAPI.Library.Lib
{
    public interface ILibraryService
    {
        Task<IEnumerable<AuthorResponse>> GetAuthorsAsync();
		Task<AuthorResponse> GetAuthorByIdAsync(int autorId);

		//Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token);

        Task<AuthorResponse> CreateAuthorAsync(AuthorCreateRequest author);
        AuthorResponse UpdateAuthor(int autorId, AuthorUpdateRequest author);
        Task<AuthorResponse> DeleteAuthorAsync(int autorId);
        Task<AuthorResponse> DeleteAuthorByNameAsync(string authorName);

		Task<IEnumerable<BookResponse>> GetBooksAsync();
		Task<BookResponse> GetBookByIdAsync(int bookId);

        //Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token);

		//Task<ILookup<int, BookResponse>> GetBooksByAuthorIdAsync(int authorId);
		//Task<ILookup<int, BookResponse>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds);
        //Task<ILookup<int, BookResponse>> GetBooksInCoAuthoringByAuthorIdsAsync(IEnumerable<int> authorIds);
        Task<BookResponse> CreateBookAsync(BookCreateRequest book);
        BookResponse UpdateBook(int bookId, BookUpdateRequest book);
        Task<BookResponse> DeleteBookAsync(int bookId);
        Task<BookResponse> DeleteBookByNameAsync(string bookName);

        Task<AuthorBookResponse> AddBookToAuthor(AuthorBookCreateRequest authorBook);
        Task<IEnumerable<BookResponse>> GetBooksByAuthorId(int authorId);
        Task<IEnumerable<BookResponse>> GetBooksByCoAuthorId(int coAuthorId);
        Task<IEnumerable<AuthorByBookIdResponse>> GetAuthorsByBookId(int bookId);
    }
}