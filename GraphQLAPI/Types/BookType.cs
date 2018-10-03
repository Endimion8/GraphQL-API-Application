using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Models;
using GraphQLAPI.Store;

namespace GraphQLAPI.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IDataStore dataStore, IDataLoaderContextAccessor accessor)
        {
            Field(x => x.Name).Description("Название книги");
            Field<AuthorType, Author>()
                .Description("Автор книги")
                .Name("Author")
                .ResolveAsync(ctx =>
                {
                    var authorsLoader = accessor.Context.GetOrAddBatchLoader<int, Author>("GetAuthorsById", dataStore.GetAuthorsByIdAsync);
                    return authorsLoader.LoadAsync(ctx.Source.AuthorId);
                });

        }
    }
}
