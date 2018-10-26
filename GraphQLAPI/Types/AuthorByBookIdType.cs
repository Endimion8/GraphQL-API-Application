using GraphQL.Types;
using Library.Lib.Response;

namespace GraphQLAPI.Types
{
    public class AuthorByBookIdType : ObjectGraphType<AuthorByBookIdResponse>
    {
        public AuthorByBookIdType()
        {
            Field(x => x.Author, true, type: typeof(AuthorType)).Description("автор");
            Field(x => x.IsAuthor).Description("true - автор, false - соавтор");
        }
    }
}
