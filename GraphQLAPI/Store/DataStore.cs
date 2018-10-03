using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLAPI.Data;
using GraphQLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Store
{
    public class DataStore : IDataStore
    {
		private readonly ApplicationDbContext _applicationDbContext;

		public DataStore(ApplicationDbContext applicationDbContext)
        {
			_applicationDbContext = applicationDbContext;
		}       

		public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _applicationDbContext.Authors.AsNoTracking().ToListAsync();
		}

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            return await _applicationDbContext.Authors.FindAsync(authorId);
        }      
        
		public async Task<Dictionary<int, Author>> GetAuthorsByIdAsync(IEnumerable<int> authorIds, CancellationToken token)
        {
            return await _applicationDbContext.Authors.Where(i => authorIds.Contains(i.AuthorId)).ToDictionaryAsync(x => x.AuthorId);
        }

		public async Task<Author> CreateAuthorAsync(Author author)
        {         
            var addedAuthor = await _applicationDbContext.Authors.AddAsync(author);
            await _applicationDbContext.SaveChangesAsync();
            return addedAuthor.Entity;
        }      
      
		public async Task<IEnumerable<Book>> GetBooksAsync()
		{
			return await _applicationDbContext.Books.AsNoTracking().ToListAsync();
		}           

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _applicationDbContext.Books.FindAsync(bookId);
		}         
      
        public async Task<Dictionary<int, Book>> GetBooksByIdAsync(IEnumerable<int> bookIds, CancellationToken token)
        {
			return await _applicationDbContext.Books.Where(i => bookIds.Contains(i.BookId)).ToDictionaryAsync(x => x.BookId);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _applicationDbContext.Books.Where(o => o.AuthorId == authorId).ToListAsync();
		}

        public async Task<ILookup<int, Book>> GetBooksByAuthorIdsAsync(IEnumerable<int> authorIds)
        {
            var books = await _applicationDbContext.Books.Where(i => authorIds.Contains(i.AuthorId)).ToListAsync();
            return books.ToLookup(i => i.AuthorId);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var addedBook = await _applicationDbContext.Books.AddAsync(book);
            await _applicationDbContext.SaveChangesAsync();
            return addedBook.Entity;
        }
	}
}
