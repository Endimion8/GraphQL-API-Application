using GraphQL.Types;
using GraphQLAPI.Queries;

namespace GraphQLAPI
{
    public class LibraryQuery : ObjectGraphType<object>, ILibraryQuery
    {
        public LibraryQuery(
            //AuthorsQuery authorsQuery,
            //BooksQuery booksQuery
            )
        {
            Name = nameof(LibraryQuery);

            //Field<AuthorsQuery>(nameof(AuthorsQuery), resolve: context => authorsQuery);
            //Field<BooksQuery>(nameof(BooksQuery), resolve: context => booksQuery);

        }
    }
}