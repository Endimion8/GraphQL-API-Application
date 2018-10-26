using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Dal.Models;
using Library.Dal.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;


namespace Library.Lib
{
    public class InitDatabase
    {
        public static void Init(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();

                Book b1 = new Book { Name = "Гарри Поттер и философский камень." };
                Book b2 = new Book { Name = "Песнь льда и пламени." };

                Author a1 = new Author { Name = "Джоан Роулинг", Birthdate = new DateTime(1965, 7, 31) };
                Author a2 = new Author { Name = "Джордж Мартин", Birthdate = new DateTime(1948, 9, 20) };

                applicationDbContext.Books.AddRange(new List<Book> { b1, b2 });
                applicationDbContext.Authors.AddRange(new List<Author> { a1, a2 });
                applicationDbContext.SaveChanges();

                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = 1, BookBookId = 1, IsAuthor = true });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = 2, BookBookId = 2, IsAuthor = true });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = 2, BookBookId = 1, IsAuthor = false });

                applicationDbContext.SaveChanges();
            }
        }
    }
}
