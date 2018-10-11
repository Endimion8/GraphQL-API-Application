using GraphQL.Types;
using GraphQLAPI.Mutations;

namespace GraphQLAPI
{
    public class LibraryMutation : ObjectGraphType<object>, ILibraryMutation
    {
        public LibraryMutation(
            //AuthorsMutation authorsMutation,
            //BooksMutation booksMutation
            )
        {
            Name = nameof(LibraryMutation);

            //Field<AuthorsMutation>(nameof(AuthorsMutation), resolve: context => authorsMutation);
            //Field<BooksMutation>(nameof(BooksMutation), resolve: context => booksMutation);

        }
    }
}
