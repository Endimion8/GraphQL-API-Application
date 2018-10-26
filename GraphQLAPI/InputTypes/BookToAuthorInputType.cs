using System;
using GraphQL.Types;
using Library.Lib.Request;

namespace GraphQLAPI.InputTypes
{
    public class BookToAuthorInputType : InputObjectGraphType<AuthorBookCreateRequest>
    {
        public BookToAuthorInputType()
        {
            Name = "AddBookToAuthorRequest";
            Description = "Модель добавления книги автору";

            Field(r => r.AuthorId).Description("Id автора");
            Field(r => r.BookId).Description("Id книги");
            Field(r => r.IsAuthor).Description("true - автор, false - соавтор");
        }
    }
}