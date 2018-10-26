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
                Book b2 = new Book { Name = "Гарри Поттер и тайная комната" };
                Book b3 = new Book { Name = "Гарри Поттер и узник Азкабана" };
                Book b4 = new Book { Name = "Гарри Поттер и кубок огня" };
                Book b5 = new Book { Name = "Гарри Поттер и орден феникса" };
                Book b6 = new Book { Name = "Гарри Поттер и принц-полукровка" };
                Book b7 = new Book { Name = "Гарри Поттер и дары смерти" };
                Book b8 = new Book { Name = "Игра престолов" };
                Book b9 = new Book { Name = "Битва королей" };
                Book b10 = new Book { Name = "Танец с драконами" };
                Book b11 = new Book { Name = "Хоббит или туда и обратно" };
                Book b12 = new Book { Name = "Властелин колец" };
                Book b13 = new Book { Name = "Сильмариллион" };
                Book b14 = new Book { Name = "Алиса в стране чудес" };

                Author a1 = new Author { Name = "Джоан Роулинг", Birthdate = new DateTime(1965, 7, 31) };
                Author a2 = new Author { Name = "Джордж Мартин", Birthdate = new DateTime(1948, 9, 20) };
                Author a3 = new Author { Name = "Льюис Кэролл", Birthdate = new DateTime(1832, 1, 27) };
                Author a4 = new Author { Name = "Джон Р. Р. Толкин", Birthdate = new DateTime(1892, 1, 3) };

                applicationDbContext.Books.AddRange(new List<Book> { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14 });
                applicationDbContext.Authors.AddRange(new List<Author> { a1, a2, a3, a4 });
                applicationDbContext.SaveChanges();

                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b1.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b2.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b3.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b4.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b5.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b6.BookId, IsAuthor = true });
                a1.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a1.AuthorId, BookBookId = b7.BookId, IsAuthor = true });

                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b8.BookId, IsAuthor = true });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b9.BookId, IsAuthor = true });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b10.BookId, IsAuthor = true });

                a3.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a3.AuthorId, BookBookId = b14.BookId, IsAuthor = true });

                a4.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a4.AuthorId, BookBookId = b11.BookId, IsAuthor = true });
                a4.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a4.AuthorId, BookBookId = b12.BookId, IsAuthor = true });
                a4.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a4.AuthorId, BookBookId = b13.BookId, IsAuthor = true });

                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b3.BookId, IsAuthor = false });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b4.BookId, IsAuthor = false });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b5.BookId, IsAuthor = false });
                a2.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a2.AuthorId, BookBookId = b14.BookId, IsAuthor = false });

                a4.AuthorBooks.Add(new AuthorBook { AuthorAuthorId = a4.AuthorId, BookBookId = b14.BookId, IsAuthor = false });

                applicationDbContext.SaveChanges();
            }
        }
    }
}
