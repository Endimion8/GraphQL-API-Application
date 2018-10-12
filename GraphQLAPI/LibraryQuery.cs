using GraphQL.Types;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Types;

namespace GraphQLAPI
{
    public class LibraryQuery : ObjectGraphType<object>, ILibraryQuery
    {
        public LibraryQuery(ILibraryService libraryService)
        {

            Field<ListGraphType<BookType>>()
                .Name("books")
                .ResolveAsync(async ctx =>
                {
                    return await libraryService.GetBooksAsync();
                });

            Field<BookType>()
                .Name("getBookById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await libraryService.GetBookByIdAsync(id);
                });

            Field<ListGraphType<AuthorType>>()
                .Name("authors")
                .ResolveAsync(async ctx =>
                {
                    return await libraryService.GetAuthorsAsync();
                });

            Field<AuthorType>()
                .Name("getAuthorById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await libraryService.GetAuthorByIdAsync(id);
                });
        }
    }
}