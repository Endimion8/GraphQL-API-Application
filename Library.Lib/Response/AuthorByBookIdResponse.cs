using GraphQLAPI.Library.Lib.Response;

namespace Library.Lib.Response
{
    public class AuthorByBookIdResponse
    {
        public AuthorResponse Author { get; set; }
        public bool IsAuthor { get; set; }

        public AuthorByBookIdResponse(AuthorResponse author, bool isAuthor)
        {
            Author = author;
            IsAuthor = isAuthor;
        }
    }
}
