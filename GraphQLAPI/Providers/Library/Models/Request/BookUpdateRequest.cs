using System;
using System.Collections.Generic;

namespace GraphQLAPI.Providers.Library.Models.Request
{
    public class BookUpdateRequest
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

    }
}
