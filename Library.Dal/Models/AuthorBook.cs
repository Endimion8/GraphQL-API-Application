using System;

namespace Library.Dal.Models
{
    public class AuthorBook
    {
        public Guid Id { get; set; }
        public int AuthorAuthorId { get; set; }
        public int BookBookId { get; set; }
        public bool IsAuthor { get; set; }
    }
}
