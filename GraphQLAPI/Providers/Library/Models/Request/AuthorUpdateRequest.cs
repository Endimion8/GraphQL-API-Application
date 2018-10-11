using System;
using System.Collections.Generic;

namespace GraphQLAPI.Providers.Library.Models.Request

{
    public class AuthorRequest
    {

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
