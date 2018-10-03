using GraphQL.Types;
using GraphQLAPI.Models;
using GraphQLAPI.Store;
using GraphQLAPI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI
{
    public class LibraryMutation : ObjectGraphType
    {
        public LibraryMutation(IDataStore dataStore)
        {
			Field<BookType, Book>()
				.Name("createBook")
				.Argument<NonNullGraphType<BookInputType>>("book", "book input")
				.ResolveAsync(ctx =>
				{
					var book = ctx.GetArgument<Book>("book");
				    return dataStore.CreateBookAsync(book);
				});

			Field<AuthorType, Author>()
                .Name("createAuthor")
                .Argument<NonNullGraphType<AuthorInputType>>("author", "author input")
                .ResolveAsync(ctx =>
                {
				    var author = ctx.GetArgument<Author>("author");
                    return dataStore.CreateAuthorAsync(author);
                });
        }
    }
}
