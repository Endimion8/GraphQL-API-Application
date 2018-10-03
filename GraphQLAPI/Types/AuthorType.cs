using System;
using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Models;
using GraphQLAPI.Store;

namespace GraphQLAPI.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IDataStore dataStore, IDataLoaderContextAccessor accessor)
        {
            Field(x => x.Name).Description("Имя автора");
            Field(x => x.Birthdate).Description("Дата рождения автора.");
            Field<ListGraphType<BookType>, IEnumerable<Book>>()
                .Name("Books")
                .ResolveAsync(ctx =>
                {
                    var booksLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Book>("GetBooksByAuthorId", dataStore.GetBooksByAuthorIdsAsync);
                    return booksLoader.LoadAsync(ctx.Source.AuthorId);
                });
        }
    }
}
