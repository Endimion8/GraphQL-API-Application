using GraphQLAPI.Library.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI.Library.Dal
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
		public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}