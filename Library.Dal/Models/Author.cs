using System;
using System.Collections.Generic;

namespace GraphQLAPI.Library.Dal.Models

{
    public class Author
    {

        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
