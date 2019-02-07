using System;

namespace Blog_BACKEND.Data
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Publication { get; set; }
        public int Author { get; set; }
        public DateTime CreationDate { get; set; }
        public int IsDeleted { get; set; }
    }
}
