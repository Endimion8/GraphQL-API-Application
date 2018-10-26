using Library.Dal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GraphQLAPI.Library.Dal.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; }

        public Book()
        {
            AuthorBooks = new List<AuthorBook>();
        }
    }
}
