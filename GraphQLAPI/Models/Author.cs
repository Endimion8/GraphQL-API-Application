using System;
using System.Collections.Generic;

namespace GraphQLAPI.Models
{
    public class Author
    {

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
