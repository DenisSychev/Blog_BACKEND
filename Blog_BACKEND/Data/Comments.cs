using System;

namespace Blog_BACKEND.Data
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Publication { get; set; }
        public string Author { get; set; }
        public int CreationDate { get; set; }
        public int IsDeleted { get; set; }
    }
}
