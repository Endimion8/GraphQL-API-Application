using System;
using GraphQL.Types;

namespace GraphQLAPI.Types
{
	public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInputType";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<DateGraphType>>("birthdate");        }
    }
}
