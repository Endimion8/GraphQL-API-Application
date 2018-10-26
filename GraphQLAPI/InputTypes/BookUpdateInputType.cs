using System;
using GraphQL.Types;
using GraphQLAPI.Library.Lib.Request;

namespace GraphQLAPI.InputTypes
{
    public class BookUpdateInputType : InputObjectGraphType<BookUpdateRequest>
    {
        public BookUpdateInputType()
        {
            Name = "BookUpdateRequest";
            Description = "Модель обновления книги";

            Field(r => r.Name).Description("Название книги");
        }
    }
}