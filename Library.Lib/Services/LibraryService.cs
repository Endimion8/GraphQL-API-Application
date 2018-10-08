using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Library.Lib.Services
{
    public class LibraryService : ILibraryService
    {
		private readonly LibraryContext _libraryContext;

		public LibraryService(LibraryContext applicationDbContext)
        {
            _libraryContext = applicationDbContext;
		}       

		public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _libraryContext.Authors.AsNoTracking().ToListAsync();
		}

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            var author = _libraryContext.Authors.FindAsync(authorId);
            return await author;
        }      
        
		public async Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token)
        {
            return await _libraryContext.Authors.Where(i => authorIds.Contains(i.AuthorId)).ToDictionaryAsync(x => x.AuthorId);
        }

		public async Task<Author> CreateAuthorAsync(Author author)
        {         
            var addedAuthor = await _libraryContext.Authors.AddAsync(author);
            await _libraryContext.SaveChangesAsync();
            return addedAuthor.Entity;
        }

        public Author UpdateAuthor(int id, Author author)
        {
            author.AuthorId = id;
            _libraryContext.Authors.Update(author);
            _libraryContext.SaveChanges();
            return author;
        }

        public async Task<Author> DeleteAuthorAsync(int authorId)
        {
            var author = await _libraryContext.Authors.FindAsync(authorId);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return author;

        }

        public async Task<Author> DeleteAuthorByNameAsync(string authorName)
        {
            var author = await _libraryContext.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
            _libraryContext.Authors.Remove(author);
            await _libraryContext.SaveChangesAsync();
            return author;
        }


        public async Task<IEnumerable<Book>> GetBooksAsync()
		{
			return await _libraryContext.Books.AsNoTracking().ToListAsync();
		}           

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _libraryContext.Books.FindAsync(bookId);
		}         
      
        public async Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token)
        {
			return await _libraryContext.Books.Where(i => bookIds.Contains(i.BookId)).ToDictionaryAsync(x => x.BookId);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _libraryContext.Books.Where(o => o.AuthorId == authorId).ToListAsync();
		}

        public async Task<ILookup<int, Book>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds)
        {
            var books = await _libraryContext.Books.Where(i => authorIds.Contains(i.AuthorId)).ToListAsync();
            return books.ToLookup(i => i.AuthorId);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var addedBook = await _libraryContext.Books.AddAsync(book);
            await _libraryContext.SaveChangesAsync();
            return addedBook.Entity;
        }

        public Book UpdateBook(int id, Book book)
        {
            book.BookId = id;
            _libraryContext.Books.Update(book);
            _libraryContext.SaveChanges();

            return book;
        }

        public async Task<Book> DeleteBookAsync(int bookId)
        {
            var book = await _libraryContext.Books.FindAsync(bookId);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return book;

        }

        public async Task<Book> DeleteBookByNameAsync(string bookName)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Name == bookName);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
            return book;

        }
    }
}
