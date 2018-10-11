using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Response;
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

		public async Task<IEnumerable<AuthorResponseLib>> GetAuthorsAsync()
        {
            var authors = await _libraryContext.Authors.AsNoTracking().ToListAsync();
            return _mapper.Map<IReadOnlyList<AuthorResponseLib>>(authors);

        }

        public async Task<AuthorResponseLib> GetAuthorByIdAsync(int authorId)
        {
            var author = await _libraryContext.Authors.FindAsync(authorId);
            return _mapper.Map<AuthorResponseLib>(author);
        }      
        
		public async Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token)
        {
            return await _libraryContext.Authors.Where(i => authorIds.Contains(i.AuthorId)).ToDictionaryAsync(x => x.AuthorId);
        }

		public async Task<AuthorResponseLib> CreateAuthorAsync(AuthorResponseLib author)
        {         
            var addedAuthor = await _libraryContext.Authors.AddAsync(_mapper.Map<Author>(author));
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponseLib>(addedAuthor.Entity);
        }

        public AuthorResponseLib UpdateAuthor(AuthorResponseLib author)
        {
            var updatedAuthor = _libraryContext.Authors.Update(_mapper.Map<Author>(author));
            _libraryContext.SaveChanges();
            return _mapper.Map<AuthorResponseLib>(updatedAuthor.Entity); ;
        }

        public async Task<AuthorResponseLib> DeleteAuthorAsync(int authorId)
        {
            var author = await _libraryContext.Authors.FindAsync(authorId);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponseLib>(author);

        }

        public async Task<AuthorResponseLib> DeleteAuthorByNameAsync(string authorName)
        {
            var author = await _libraryContext.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<AuthorResponseLib>(author);
        }


        public async Task<IEnumerable<BookResponseLib>> GetBooksAsync()
		{
            var books = await _libraryContext.Books.AsNoTracking().ToListAsync();
            return _mapper.Map<List<BookResponseLib>>(books);
        }           

        public async Task<BookResponseLib> GetBookByIdAsync(int bookId)
        {
            var book = await _libraryContext.Books.FindAsync(bookId);
            return _mapper.Map<BookResponseLib>(book);
        }         
      
        public async Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token)
        {
			return await _libraryContext.Books.Where(i => bookIds.Contains(i.BookId)).ToDictionaryAsync(x => x.BookId);
        }

        public async Task<IEnumerable<BookResponseLib>> GetBooksByAuthorIdAsync(int authorId)
        {
            var books = await _libraryContext.Books.Where(o => o.AuthorId == authorId).ToListAsync();
            return _mapper.Map<IReadOnlyList<BookResponseLib>>(books);
		}

        public async Task<List<BookResponseLib>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds)
        {
            var books = await _libraryContext.Books.Where(i => authorIds.Contains(i.AuthorId)).ToListAsync();
            return _mapper.Map<List<BookResponseLib>>(books);
        }

        public async Task<BookResponseLib> CreateBookAsync(BookResponseLib book)
        {
            var addedBook = await _libraryContext.Books.AddAsync(_mapper.Map<Book>(book));
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponseLib>(addedBook.Entity);
        }

        public BookResponseLib UpdateBook(BookResponseLib book)
        {
            var updatedBook = _libraryContext.Books.Update(_mapper.Map<Book>(book));
            _libraryContext.SaveChanges();

            return _mapper.Map<BookResponseLib>(updatedBook.Entity); ;
        }

        public async Task<BookResponseLib> DeleteBookAsync(int bookId)
        {
            var book = await _libraryContext.Books.FindAsync(bookId);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponseLib>(book);

        }

        public async Task<BookResponseLib> DeleteBookByNameAsync(string bookName)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Name == bookName);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return _mapper.Map<BookResponseLib>(book);

        }
    }
}
