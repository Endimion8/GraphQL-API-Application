using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI;
using GraphQLAPI.Models;
using GraphQLAPI.Store;
using GraphQLAPI.Types;

namespace GraphQLAPI
{
    public class LibraryQuery : ObjectGraphType
    {
        public LibraryQuery(IDataLoaderContextAccessor accessor, IDataStore dataStore)
        {

            Field<ListGraphType<BookType>, IEnumerable<Book>>()
                .Name("Books")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetBooksAsync();
                });

            Field<ListGraphType<AuthorType>, IEnumerable<Author>>()
                .Name("Authors")
                .ResolveAsync(ctx =>
                {
                    return dataStore.GetAuthorsAsync();
                });
        }
    }
}