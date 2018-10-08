using GraphQL.Types;
using GraphQLAPI.Library.Dal.Models;
using GraphQLAPI.Library.Lib.Types;

namespace GraphQLAPI.Library.Lib
{
    public class LibraryMutation : ObjectGraphType
    {
        public LibraryMutation(ILibraryService libraryService)
        {
			Field<BookType, Book>()
				.Name("createBook")
				.Argument<NonNullGraphType<BookInputType>>("book", "book input")
				.ResolveAsync(ctx =>
				{
					var book = ctx.GetArgument<Book>("book");
				    return libraryService.CreateBookAsync(book);
				});

            Field<BookType, Book>()
                .Name("updateBook")
                .Argument<NonNullGraphType<IntGraphType>>("bookId", "book id")
                .Argument<NonNullGraphType<BookInputType>>("book", "book input")
                .Resolve(ctx =>
                {
                    var bookId = ctx.GetArgument<int>("bookId");
                    var book = ctx.GetArgument<Book>("book");
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
                .Argument<NonNullGraphType<AuthorInputType>>("author", "author input")
                .ResolveAsync(ctx =>
                {
				    var author = ctx.GetArgument<Author>("author");
                    return libraryService.CreateAuthorAsync(author);
                });

            Field<AuthorType, Author>()
                .Name("updateAuthor")
                .Argument<NonNullGraphType<IntGraphType>>("authorId", "author id")
                .Argument<NonNullGraphType<AuthorInputType>>("author", "author input")
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
