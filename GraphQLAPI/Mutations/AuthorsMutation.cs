using GraphQL.Types;
using GraphQLAPI.InputTypes;
using GraphQLAPI.Providers;
using GraphQLAPI.Providers.Library.Models.Response;
using GraphQLAPI.Types;

namespace GraphQLAPI.Mutations
{
    public class AuthorsMutation : ObjectGraphType
    {
        public AuthorsMutation(IAuthorsProvider authorsProvider)
        {
            //Field<AuthorType, AuthorResponse>()
            //    .Name("createAuthor")
            //    .Argument<NonNullGraphType<AuthorInputType>>("author", "author input")
            //    .ResolveAsync(ctx =>
            //    {
            //        var author = ctx.GetArgument<AuthorResponse>("author");
            //        return authorsProvider.CreateAuthorAsync(author);
            //    });

            //Field<AuthorType, AuthorResponse>()
            //    .Name("updateAuthor")
            //    .Argument<NonNullGraphType<IntGraphType>>("authorId", "author id")
            //    .Argument<NonNullGraphType<AuthorInputType>>("author", "author input")
            //    .Resolve(ctx =>
            //    {
            //        var authorId = ctx.GetArgument<int>("authorId");
            //        var author = ctx.GetArgument<AuthorResponse>("author");
            //        return authorsProvider.UpdateAuthor(authorId, author);
            //    });

            //Field<AuthorType, AuthorResponse>()
            //    .Name("deleteAuthorByName")
            //    .Argument<NonNullGraphType<StringGraphType>>("name", "author name")
            //    .ResolveAsync(ctx =>
            //    {
            //        var name = ctx.GetArgument<string>("name");
            //        return authorsProvider.DeleteAuthorByNameAsync(name);
            //    });

            //Field<AuthorType, AuthorResponse>()
            //    .Name("deleteAuthorById")
            //    .Argument<NonNullGraphType<IntGraphType>>("id", "author id")
            //    .ResolveAsync(ctx =>
            //    {
            //        var id = ctx.GetArgument<int>("id");
            //        return authorsProvider.DeleteAuthorAsync(id);
            //    });
        }
    }
}
