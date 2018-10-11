using System;
using GraphQL.Types;

namespace GraphQLAPI.InputTypes
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
