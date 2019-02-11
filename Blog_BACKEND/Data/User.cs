using System;
using System.Collections.Generic;

namespace Blog_BACKEND.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreationDate { get; set; }
        public int LastLoginDate { get; set;  }

        public List<Publications> Publications { get; set; }
    }
}
