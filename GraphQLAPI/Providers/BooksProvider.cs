using AutoMapper;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Response;
using GraphQLAPI.Providers.Library.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Providers
{
    public class BooksProvider: IBooksProvider
    {
        private readonly IMapper _mapper;
        private readonly ILibraryService _libraryService;

        BooksProvider(ILibraryService libraryService, IMapper mapper)
        {
            _mapper = mapper;
            _libraryService = libraryService;
        }

        public async Task<IEnumerable<Library.Models.Response.BookResponse>> GetBooksAsync()
        {
            var books = await _libraryService.GetBooksAsync();
            return _mapper.Map<IReadOnlyList<Library.Models.Response.BookResponse>>(books);
        }

        public async Task<Library.Models.Response.BookResponse> GetBookByIdAsync(int bookId)
        {
            var book = await _libraryService.GetBookByIdAsync(bookId);
            return _mapper.Map<Library.Models.Response.BookResponse>(book);
        }

        public async Task<IEnumerable<Library.Models.Response.BookResponse>> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await _libraryService.GetBooksByAuthorIdAsync(authorId);
            return _mapper.Map<IReadOnlyList<Library.Models.Response.BookResponse>>(books);
        }

        public async Task<ILookup<int, Library.Models.Response.BookResponse>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds)
        {
            var books = await _libraryService.GetBooksByAuthorIdsAsync(authorIds);
            return _mapper.Map<IReadOnlyList<Library.Models.Response.BookResponse>>(books).ToLookup(i => i.AuthorId);
        }

        public async Task<Library.Models.Response.BookResponse> CreateBookAsync(Library.Models.Response.BookResponse book)
        {
            var addedBook = await _libraryService.CreateBookAsync(_mapper.Map<GraphQLAPI.Library.Lib.Response.BookResponse>(book));
            return _mapper.Map<Library.Models.Response.BookResponse>(addedBook);
        }

        public BookResponse UpdateBook(int id, Library.Models.Response.BookResponse book)
        {
            book.BookId = id;
            var updatedBook = _libraryService.UpdateBook(_mapper.Map<GraphQLAPI.Library.Lib.Response.BookResponse>(book));
            return _mapper.Map<Library.Models.Response.BookResponse>(updatedBook);
        }

        public async Task<Library.Models.Response.BookResponse> DeleteBookAsync(int bookId)
        {
            var book = await _libraryService.DeleteBookAsync(bookId);
            return _mapper.Map<Library.Models.Response.BookResponse>(book);

        }

        public async Task<Library.Models.Response.BookResponse> DeleteBookByNameAsync(string bookName)
        {
            var book = await _libraryService.DeleteBookByNameAsync(bookName);
            return _mapper.Map<Library.Models.Response.BookResponse>(book);

        }
    }
}
