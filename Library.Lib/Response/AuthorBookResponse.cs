using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Lib.Response
{
    public class AuthorBookResponse
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public bool IsAuthor { get; set; }
    }
}
