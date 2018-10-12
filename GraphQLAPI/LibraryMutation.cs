using GraphQL.Types;
using GraphQLAPI.InputTypes;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Request;
using GraphQLAPI.Mutations;
using GraphQLAPI.Types;

namespace GraphQLAPI
{
    public class LibraryMutation : ObjectGraphType<object>, ILibraryMutation
    {
        public LibraryMutation(ILibraryService libraryService)
        {
            Field<BookType>()
                .Name("createBook")
                .Argument<NonNullGraphType<BookCreateInputType>>("book", "book input")
                .ResolveAsync(async ctx =>
                {
                    var book = ctx.GetArgument<BookCreateRequest>("book");
                    return await libraryService.CreateBookAsync(book);
                });

            Field<BookType>()
                .Name("updateBook")
                .Argument<NonNullGraphType<IntGraphType>>("bookId", "book id")
                .Argument<NonNullGraphType<BookUpdateInputType>>("book", "book input")
                .Resolve(ctx =>
                {
                    var bookId = ctx.GetArgument<int>("bookId");
                    var book = ctx.GetArgument<BookUpdateRequest>("book");
                    return libraryService.UpdateBook(bookId, book);
                });

            Field<BookType, Book>()
                .Name("deleteBookByName")
                .Argument<NonNullGraphType<StringGraphType>>("name", "book name")
                .ResolveAsync(ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    return libraryService.DeleteBookByNameAsync(name);
                });

            Field<BookType, Book>()
                .Name("deleteBookById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return libraryService.DeleteBookAsync(id);
                });

            Field<AuthorType, Author>()
                .Name("createAuthor")
                .Argument<NonNullGraphType<AuthorCreateInputType>>("author", "author input")
                .ResolveAsync(ctx =>
                {
                    var author = ctx.GetArgument<Author>("author");
                    return libraryService.CreateAuthorAsync(author);
                });

            Field<AuthorType, Author>()
                .Name("updateAuthor")
                .Argument<NonNullGraphType<IntGraphType>>("authorId", "author id")
                .Argument<NonNullGraphType<AuthorCreateInputType>>("author", "author input")
                .Resolve(ctx =>
                {
                    var authorId = ctx.GetArgument<int>("authorId");
                    var author = ctx.GetArgument<Author>("author");
                    return libraryService.UpdateAuthor(authorId, author);
                });

            Field<AuthorType, Author>()
                .Name("deleteAuthorByName")
                .Argument<NonNullGraphType<StringGraphType>>("name", "author name")
                .ResolveAsync(ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    return libraryService.DeleteAuthorByNameAsync(name);
                });

            Field<AuthorType, Author>()
                .Name("deleteAuthorById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
                .ResolveAsync(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return libraryService.DeleteAuthorAsync(id);
                });
        }
    }
}
