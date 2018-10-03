using System;
using System.Collections.Generic;

namespace GraphQLAPI.Models
{
    public class Book
    {
    
        public int BookId { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}
