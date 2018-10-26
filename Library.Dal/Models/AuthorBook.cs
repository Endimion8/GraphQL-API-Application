using GraphQLAPI.Library.Dal.Models;

namespace Library.Dal.Models
{
    public class AuthorBook
    {
        public int AuthorAuthorId { get; set; }
        public Author Author { get; set; }
        public int BookBookId { get; set; }
        public Book Book { get; set; }
        public bool IsAuthor { get; set; }
    }
}
