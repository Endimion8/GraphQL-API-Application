﻿using System;
using System.Collections.Generic;

namespace GraphQLAPI.Library.Lib.Request

{
    public class AuthorUpdateRequest
    {

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
