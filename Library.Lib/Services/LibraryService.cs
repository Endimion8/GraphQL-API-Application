using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Request;
using GraphQLAPI.Library.Lib.Response;
using Library.Lib;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Library.Lib.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IMapper _mapper;
        private readonly LibraryContext _libraryContext;

		public LibraryService(LibraryContext applicationDbContext, IMapper mapper)
        {
            _libraryContext = applicationDbContext;
            _mapper = mapper;
        }       

		public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
        {
            var authors = await _libraryContext.Authors.AsNoTracking().ToListAsync();
            return _mapper.Map<IReadOnlyList<AuthorResponse>>(authors);

        }

        public async Task<AuthorResponse> GetAuthorByIdAsync(int authorId)
        {
            var author = await _libraryContext.Authors.FindAsync(authorId);
            return _mapper.Map<AuthorResponse>(author);
        }      
        
		//public async Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token)
  //      {
  //          return await _libraryContext.Authors.Where(i => authorIds.Contains(i.AuthorId)).ToDictionaryAsync(x => x.AuthorId);
  //      }

		public async Task<AuthorResponse> CreateAuthorAsync(AuthorCreateRequest author)
        {         
            var addedAuthor = await _libraryContext.Authors.AddAsync(_mapper.Map<Author>(author));
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponse>(addedAuthor.Entity);
        }

        public AuthorResponse UpdateAuthor(int authorId, AuthorUpdateRequest author)
        {
            Mapper.Initialize(x => x.AddProfile(typeof(LibraryMappingProfile)));
            var authorToUpdate = Mapper.Map<Author>(author);
            authorToUpdate.AuthorId = authorId;

            var updatedAuthor = _libraryContext.Authors.Update(authorToUpdate);
            _libraryContext.SaveChanges();
            return _mapper.Map<AuthorResponse>(updatedAuthor.Entity); ;
        }

        public async Task<AuthorResponse> DeleteAuthorAsync(int authorId)
        {
            var author = await _libraryContext.Authors.FindAsync(authorId);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponse>(author);

        }

        public async Task<AuthorResponse> DeleteAuthorByNameAsync(string authorName)
        {
            var author = await _libraryContext.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponse>(author);
        }


        public async Task<IEnumerable<BookResponse>> GetBooksAsync()
		{
            var books = await _libraryContext.Books.AsNoTracking().ToListAsync();
            return _mapper.Map<List<BookResponse>>(books);
        }           

        public async Task<BookResponse> GetBookByIdAsync(int bookId)
        {
            var book = await _libraryContext.Books.FindAsync(bookId);
            return _mapper.Map<BookResponse>(book);
        }         
      
   //     public async Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token)
   //     {
			//return await _libraryContext.Books.Where(i => bookIds.Contains(i.BookId)).ToDictionaryAsync(x => x.BookId);
   //     }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await _libraryContext.Books.Where(o => o.AuthorId == authorId).ToListAsync();
            return _mapper.Map<IReadOnlyList<BookResponse>>(books);
		}

        public async Task<ILookup<int, BookResponse>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds)
        {
            var books = await _libraryContext.Books.Where(i => authorIds.Contains(i.AuthorId)).ToListAsync();
            return _mapper.Map<IReadOnlyList<BookResponse>>(books).ToLookup(i => i.AuthorId);
        }

        public async Task<BookResponse> CreateBookAsync(BookCreateRequest book)
        {
            var addedBook = await _libraryContext.Books.AddAsync(_mapper.Map<Book>(book));
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponse>(addedBook.Entity);
        }

        public BookResponse UpdateBook(int bookId, BookUpdateRequest book)
        {
            Mapper.Initialize(x => x.AddProfile(typeof(LibraryMappingProfile)));
            var bookToUpdate = Mapper.Map<Book>(book);
            bookToUpdate.BookId = bookId;

            var updatedBook = _libraryContext.Books.Update(bookToUpdate);
            _libraryContext.SaveChanges();

            return _mapper.Map<BookResponse>(updatedBook.Entity); ;
        }

        public async Task<BookResponse> DeleteBookAsync(int bookId)
        {
            var book = await _libraryContext.Books.FindAsync(bookId);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponse>(book);

        }

        public async Task<BookResponse> DeleteBookByNameAsync(string bookName)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Name == bookName);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponse>(book);

        }
    }
}
