using GraphQLAPI.Library.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Dal
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddLibraryDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<LibraryContext>(options => options.UseNpgsql(configuration["DefaultConnection"]));

            return services;
        }
    }
}
