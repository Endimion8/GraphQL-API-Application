using GraphQL.Types;
using GraphQLAPI.Library.Dal;
using GraphQLAPI.Library.Lib.Services;
using GraphQLAPI.Library.Lib.Types;
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

            services.AddScoped<LibraryQuery>();
            services.AddScoped<LibraryMutation>();
            services.AddScoped<ISchema, LibrarySchema>();

            services.AddScoped<AuthorType>();
            services.AddScoped<AuthorInputType>();

            services.AddScoped<BookType>();
            services.AddScoped<BookInputType>();

            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}
