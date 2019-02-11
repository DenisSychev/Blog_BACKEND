using System;

namespace Blog_BACKEND.Data
{
    public class Publications
    {
        public int IdPublication { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int CreationDate { get; set; }
        public int IsDeleted { get; set; }
    }
}
