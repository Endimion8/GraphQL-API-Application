using GraphQLAPI.Library.Lib.Services;
using Library.Dal;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GraphQLAPI.Library.Lib
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLibraryDal(configuration);

            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}
