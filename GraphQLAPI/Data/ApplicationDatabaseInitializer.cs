using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLAPI.Data
{
    public class ApplicationDatabaseInitializer
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await applicationDbContext.Database.EnsureDeletedAsync();
                await applicationDbContext.Database.MigrateAsync();
                await applicationDbContext.Database.EnsureCreatedAsync();

				var books = new List<Book>
				{
					new Book { Name = "Гарри Поттер и философский камень.", Author = new Author { Name = "Джоан Роулинг", Birthdate = new DateTime(1965, 7, 31)} },
					new Book { Name = "Песнь льда и пламени.", Author = new Author { Name = "Джордж Мартин", Birthdate = new DateTime(1948, 9, 20)} }
				};

				await applicationDbContext.Books.AddRangeAsync(books);

				await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}