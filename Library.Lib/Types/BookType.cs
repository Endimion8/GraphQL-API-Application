using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLAPI.Library.Dal.Models;

namespace GraphQLAPI.Library.Lib.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(ILibraryService libraryService, IDataLoaderContextAccessor accessor)
        {
            Field(x => x.BookId).Description("Id книги");
            Field(x => x.Name).Description("Название книги");
            Field(x => x.AuthorId).Description("Id автора книги");
        }
    }
}
