using GraphQL.Types;
using GraphQLAPI.InputTypes;
using GraphQLAPI.Providers;
using GraphQLAPI.Providers.Library.Models.Response;
using GraphQLAPI.Types;

namespace GraphQLAPI.Mutations
{
    public class BooksMutation : ObjectGraphType
    {
        public BooksMutation(IBooksProvider booksProvider)
        {
			//Field<BookType, BookResponse>()
			//	.Name("createBook")
			//	.Argument<NonNullGraphType<BookInputType>>("book", "book input")
			//	.ResolveAsync(ctx =>
			//	{
			//		var book = ctx.GetArgument<BookResponse>("book");
			//	    return booksProvider.CreateBookAsync(book);
			//	});

   //         Field<BookType, BookResponse>()
   //             .Name("updateBook")
   //             .Argument<NonNullGraphType<IntGraphType>>("bookId", "book id")
   //             .Argument<NonNullGraphType<BookInputType>>("book", "book input")
   //             .Resolve(ctx =>
   //             {
   //                 var bookId = ctx.GetArgument<int>("bookId");
   //                 var book = ctx.GetArgument<BookResponse>("book");
   //                 return booksProvider.UpdateBook(bookId, book);
   //             });

   //         Field<BookType, BookResponse>()
			//	.Name("deleteBookByName")
			//	.Argument<NonNullGraphType<StringGraphType>>("name", "book name")
			//	.ResolveAsync(ctx =>
			//	{
			//		var name = ctx.GetArgument<string>("name");
   //                 return booksProvider.DeleteBookByNameAsync(name);
			//	});

   //         Field<BookType, BookResponse>()
			//	.Name("deleteBookById")
			//	.Argument<NonNullGraphType<IntGraphType>>("id", "book id")
			//	.ResolveAsync(ctx =>
			//	{
			//		var id = ctx.GetArgument<int>("id");
   //                 return booksProvider.DeleteBookAsync(id);
			//	});
        }
    }
}
