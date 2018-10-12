using System;
using GraphQL.Types;
using GraphQLAPI.Library.Lib.Request;

namespace GraphQLAPI.InputTypes
{
	public class AuthorCreateInputType : InputObjectGraphType<AuthorCreateRequest>
    {
        public AuthorCreateInputType()
        {
            Name = "AuthorCreateRequest";
            Description = "Модель создания автора";

            Field(r => r.Name).Description("Имя автора");
            Field(r => r.Birthdate, true, type: typeof(DateGraphType)).Description("Дата рождения");
        }
    }
}
