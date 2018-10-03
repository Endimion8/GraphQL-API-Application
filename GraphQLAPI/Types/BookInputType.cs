using System;
using GraphQL.Types;
using GraphQLAPI.Models;

namespace GraphQLAPI.Types
{
	public class BookInputType : InputObjectGraphType
    {
		public BookInputType()
		{
			Name = "BookInput";
            Field<NonNullGraphType<StringGraphType>>("name");
			Field<NonNullGraphType<IntGraphType>>("authorId");
        }
    }
}
