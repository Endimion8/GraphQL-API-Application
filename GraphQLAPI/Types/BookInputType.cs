using System;
using GraphQL.Types;
using GraphQLAPI.Models;

namespace GraphQLAPI.Types
{
	public class BookInputType : InputObjectGraphType
    {
		public BookInputType()
		{
			Name = "BookInputType";
            Field<NonNullGraphType<StringGraphType>>("name");
			Field<NonNullGraphType<IntGraphType>>("authorId");
        }
    }
}
