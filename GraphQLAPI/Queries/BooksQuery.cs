using GraphQL.Types;
using GraphQLAPI.Providers;
using GraphQLAPI.Providers.Library.Models.Response;
using GraphQLAPI.Types;
using System.Collections.Generic;

namespace GraphQLAPI.Queries
{
    public class BooksQuery : ObjectGraphType
    {
        public BooksQuery(IBooksProvider booksProvider)
        {
            Field<ListGraphType<BookType>>()
                .Name("books")
                .ResolveAsync(async ctx =>
                {
                    return await booksProvider.GetBooksAsync();
                });

            Field<BookType>()
                .Name("getBookById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await booksProvider.GetBookByIdAsync(id);
                });
        }
    }
}
