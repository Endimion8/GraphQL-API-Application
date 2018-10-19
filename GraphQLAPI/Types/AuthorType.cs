﻿using System;
using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Response;

namespace GraphQLAPI.Types
{
    public class AuthorType : ObjectGraphType<AuthorResponse>
    {
        public AuthorType(ILibraryService libraryService, IDataLoaderContextAccessor accessor)
        {
            Field(x => x.AuthorId).Description("Id автора");
            Field(x => x.Name).Description("Имя автора");
            Field(x => x.Birthdate).Description("Дата рождения автора.");
            Field<ListGraphType<BookType>, IEnumerable<BookResponse>>()
                .Description("Книги автора")
                .Name("Books")
                .ResolveAsync(ctx =>
                {
                    var booksLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, BookResponse>("GetBooksByAuthorId", libraryService.GetBooksByAuthorIdsAsync);
                    return booksLoader.LoadAsync(ctx.Source.AuthorId);
                });
        }
    }
}
