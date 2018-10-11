using System;
using System.Collections.Generic;

namespace GraphQLAPI.Providers.Library.Models.Response
{
    public class BookResponse
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

    }
}
