using AutoMapper;
using GraphQLAPI.Library.Lib.Services;
using Library.Dal;
using Library.Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GraphQLAPI.Library.Lib
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddLibrary(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLibraryDal(configuration);

            services.AddAutoMapper(x => x.AddProfile(typeof(LibraryMappingProfile)));
            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}
