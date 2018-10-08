using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Dal.Models;
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

                var books = new List<Book>
                {
                    new Book { Name = "Гарри Поттер и философский камень.", AuthorId = 1 },
                    new Book { Name = "Песнь льда и пламени.", AuthorId = 2 },
                };

                var authors = new List<Author>
                {
                    new Author { Name = "Джоан Роулинг", Birthdate = new DateTime(1965, 7, 31) },
                    new Author { Name = "Джордж Мартин", Birthdate = new DateTime(1948, 9, 20)}
                };

                applicationDbContext.Books.AddRange(books);
                applicationDbContext.Authors.AddRange(authors);

                applicationDbContext.SaveChanges();
            }
        }
    }
}
