using System;
using GraphQL.Types;
using GraphQLAPI.Library.Lib.Request;

namespace GraphQLAPI.InputTypes
{
	public class AuthorUpdateInputType : InputObjectGraphType<AuthorUpdateRequest>
    {
        public AuthorUpdateInputType()
        {
            Name = "AuthorUpdateRequest";
            Description = "Модель обновления автора";

            Field(r => r.Name).Description("Имя автора");
            Field(r => r.Birthdate, true, type: typeof(DateGraphType)).Description("Дата рождения");
        }
    }
}
