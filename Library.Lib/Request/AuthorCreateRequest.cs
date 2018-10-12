using System;
using System.Collections.Generic;

namespace GraphQLAPI.Library.Lib.Request

{
    public class AuthorCreateRequest
    {

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
