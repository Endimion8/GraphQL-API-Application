using GraphQL.Types;
using Library.Lib.Response;

namespace GraphQLAPI.Types
{
    public class AuthorBookType : ObjectGraphType<AuthorBookResponse>
    {
        public AuthorBookType()
        {
            Field(x => x.AuthorId).Description("Id автора");
            Field(x => x.BookId).Description("Id книги");
            Field(x => x.IsAuthor).Description("Признак главного автора");
        }
    }
}
