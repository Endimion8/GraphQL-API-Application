using GraphQL.Types;
using GraphQLAPI.Providers;
using GraphQLAPI.Types;

namespace GraphQLAPI.Queries
{
    public class AuthorsQuery : ObjectGraphType
    {
        public AuthorsQuery(IAuthorsProvider authorsProvider)
        {
            Field<ListGraphType<AuthorType>>()
                .Name("authors")
                .ResolveAsync(async ctx =>
                {
                    return await authorsProvider.GetAuthorsAsync();
                });

            Field<AuthorType>()
                .Name("getAuthorById")
                .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
                .ResolveAsync(async ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return await authorsProvider.GetAuthorByIdAsync(id);
                });
        }

    }
}
