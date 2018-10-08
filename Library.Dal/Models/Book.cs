using System;
using System.Collections.Generic;

namespace GraphQLAPI.Library.Dal.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

    }
}
