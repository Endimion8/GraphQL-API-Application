using System;
using GraphQL.Types;

namespace GraphQLAPI.InputTypes
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
