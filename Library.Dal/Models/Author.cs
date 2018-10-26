using Library.Dal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphQLAPI.Library.Dal.Models

{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; }

        public Author()
        {
            AuthorBooks = new List<AuthorBook>();
        }

    }
}
