using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Library.Lib;
using GraphQLAPI.Library.Lib.Response;

namespace GraphQLAPI.Types
{
    public class BookType : ObjectGraphType<BookResponse>
    {
        public BookType(ILibraryService libraryService)
        {
            Field(x => x.BookId).Description("Id книги");
            Field(x => x.Name).Description("Название книги");
            //Field(x => x.AuthorId).Description("Id автора книги");
        }
    }
}
