using System;
using System.Collections.Generic;

namespace GraphQLAPI.Library.Lib.Request
{
    public class BookCreateRequest
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

    }
}
