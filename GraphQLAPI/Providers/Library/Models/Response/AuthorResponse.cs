using System;
using System.Collections.Generic;

namespace GraphQLAPI.Providers.Library.Models.Response

{
    public class AuthorResponse
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
