using GraphQL;
using GraphQL.Http;
using GraphQLAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.DataLoader;
using GraphQLAPI.Library.Lib;
using Library.Lib;
using GraphQL.Types;
using GraphQLAPI.Types;
using GraphQLAPI.InputTypes;

namespace GraphQLAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
		{
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            services.AddScoped<ILibraryQuery, LibraryQuery>();
            services.AddScoped<ILibraryMutation, LibraryMutation>();
            services.AddScoped<ISchema, LibrarySchema>();

            services.AddScoped<AuthorType>();
            services.AddScoped<AuthorCreateInputType>();

            services.AddScoped<BookType>();
            services.AddScoped<BookCreateInputType>();

            services.AddLibrary(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMiddleware<GraphQLMiddleware>();
            ApplicationDatabaseInitializer.Initialize(app);
            InitDatabase.Init(app);
        }
    }
}
