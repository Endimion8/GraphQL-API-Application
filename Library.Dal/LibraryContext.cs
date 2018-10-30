using GraphQLAPI.Library.Dal.Models;
using Library.Dal.Models;
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
        public object AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasIndex(t => new { t.AuthorAuthorId, t.BookBookId }).IsUnique();

            //modelBuilder.Entity<AuthorBook>()
            //.HasOne(sc => sc.Author)
            //.WithMany(s => s.AuthorBooks)
            //.HasForeignKey(sc => sc.AuthorAuthorId);

            //modelBuilder.Entity<AuthorBook>()
            //    .HasOne(sc => sc.Book)
            //    .WithMany(c => c.AuthorBooks)
            //    .HasForeignKey(sc => sc.BookBookId);
        }
    }
}