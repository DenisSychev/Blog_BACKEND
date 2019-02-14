using System;
using System.Collections.Generic;

namespace Blog_BACKEND.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreationDate { get; set; }
        public int LastLoginDate { get; set;  }

        public List<Publication> Publication { get; set; }
    }
}
