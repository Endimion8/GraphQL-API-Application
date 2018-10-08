using System.Collections.Generic;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Types;

namespace GraphQLAPI.Library.Lib
{
    public class LibraryQuery : ObjectGraphType
    {
        public LibraryQuery(IDataLoaderContextAccessor accessor, ILibraryService libraryService)
        {

            Field<ListGraphType<BookType>, IEnumerable<Book>>()
                .Name("books")
                .ResolveAsync(ctx =>
                {
                    return libraryService.GetBooksAsync();
                });

            Field<BookType, Book>()
                .Name("getBookById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return libraryService.GetBookByIdAsync(id);
                });

            Field<ListGraphType<AuthorType>, IEnumerable<Author>>()
                .Name("authors")
                .ResolveAsync(ctx =>
                {
                    return libraryService.GetAuthorsAsync();
                });

            Field<AuthorType, Author>()
                .Name("getAuthorById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
                .ResolveAsync(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return libraryService.GetAuthorByIdAsync(id);
                });
        }
    }
}