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

            Field<ListGraphType<BookType>>()
                .Name("booksByAuthorId")
                .Argument<NonNullGraphType<IntGraphType>>("authorId", "author id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("authorId");
                    return await libraryService.GetBooksByAuthorId(id);
                });

            Field<ListGraphType<BookType>>()
                .Name("booksByCoAuthorId")
                .Argument<NonNullGraphType<IntGraphType>>("coAuthorId", "coAuthor id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("coAuthorId");
                    return await libraryService.GetBooksByCoAuthorId(id);
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

            Field<ListGraphType<AuthorByBookIdType>>()
                .Name("getAuthorsByBookId")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await libraryService.GetAuthorsByBookId(id);
                });
        }
    }
}