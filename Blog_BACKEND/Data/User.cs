using System;

namespace Blog_BACKEND.Data
{
    public class User
    {
        public int Id { get; set; }
        public Guid UserGUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLoginDate { get; set;  }
    }
}
