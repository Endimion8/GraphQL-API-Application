using System;
using GraphQL.Types;

namespace GraphQLAPI.Library.Lib.Types
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
