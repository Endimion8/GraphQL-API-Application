using System;
using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Library.Dal.Models;

namespace GraphQLAPI.Library.Lib.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(ILibraryService libraryService, IDataLoaderContextAccessor accessor)
        {
            Field(x => x.AuthorId).Description("Id автора");
            Field(x => x.Name).Description("Имя автора");
            Field(x => x.Birthdate).Description("Дата рождения автора.");
            Field<ListGraphType<BookType>, IEnumerable<Book>>()
                .Description("Книги автора")
                .Name("Books")
                .ResolveAsync(ctx =>
                {
                    var booksLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Book>("GetBooksByAuthorId", libraryService.GetBooksByAuthorIdsAsync);
                    return booksLoader.LoadAsync(ctx.Source.AuthorId);
                });
        }
    }
}
