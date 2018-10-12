using System;
using GraphQL.Types;
using GraphQLAPI.Library.Lib.Request;

namespace GraphQLAPI.InputTypes
{
	public class BookCreateInputType : InputObjectGraphType<BookCreateRequest>
    {
		public BookCreateInputType()
		{
			Name = "BookCreateRequest";
            Description = "Модель создания книги";

            Field(r => r.Name).Description("Название книги");
            Field(r => r.AuthorId).Description("Id автора");
        }
    }
}
