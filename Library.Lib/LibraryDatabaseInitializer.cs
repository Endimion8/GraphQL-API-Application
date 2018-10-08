using System.Threading.Tasks;
using GraphQLAPI.Library.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLAPI.Library.Lib
{
    public class ApplicationDatabaseInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();

                applicationDbContext.Database.EnsureDeleted();
                applicationDbContext.Database.Migrate();
                applicationDbContext.Database.EnsureCreated();
            }
        }
    }
}