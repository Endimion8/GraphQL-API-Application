using GraphQL.Types;
using GraphQLAPI.InputTypes;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Request;
using GraphQLAPI.Types;
using Library.Lib.Request;

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
                    var newBook = await libraryService.CreateBookAsync(book);
                    return newBook;
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

            Field<BookType>()
                .Name("deleteBookByName")
                .Argument<NonNullGraphType<StringGraphType>>("name", "book name")
                .ResolveAsync(async ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    return await libraryService.DeleteBookByNameAsync(name);
                });

            Field<BookType>()
                .Name("deleteBookById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "book id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await libraryService.DeleteBookAsync(id);
                });

            Field<AuthorType>()
                .Name("createAuthor")
                .Argument<NonNullGraphType<AuthorCreateInputType>>("author", "author input")
                .ResolveAsync(async ctx =>
                {
                    var author = ctx.GetArgument<AuthorCreateRequest>("author");
                    return await libraryService.CreateAuthorAsync(author);
                });

            Field<AuthorType>()
                .Name("updateAuthor")
                .Argument<NonNullGraphType<IntGraphType>>("authorId", "author id")
                .Argument<NonNullGraphType<AuthorCreateInputType>>("author", "author input")
                .Resolve(ctx =>
                {
                    var authorId = ctx.GetArgument<int>("authorId");
                    var author = ctx.GetArgument<AuthorUpdateRequest>("author");
                    return libraryService.UpdateAuthor(authorId, author);
                });

            Field<AuthorType>()
                .Name("deleteAuthorByName")
                .Argument<NonNullGraphType<StringGraphType>>("name", "author name")
                .ResolveAsync(async ctx =>
                {
                    var name = ctx.GetArgument<string>("name");
                    return await libraryService.DeleteAuthorByNameAsync(name);
                });

            Field<AuthorType>()
                .Name("deleteAuthorById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await libraryService.DeleteAuthorAsync(id);
                });
            Field<AuthorBookType>()
                .Name("addBookToAuthor")
                .Argument<NonNullGraphType<BookToAuthorInputType>>("bookToAuthor", "book to autor")
                .ResolveAsync(async ctx =>
                {
                    var bookAuthor = ctx.GetArgument<AuthorBookCreateRequest>("bookToAuthor");
                    return await libraryService.AddBookToAuthor(bookAuthor);
                });
        }
    }
}
