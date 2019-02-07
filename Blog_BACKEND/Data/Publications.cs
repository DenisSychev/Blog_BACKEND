using System;

namespace Blog_BACKEND.Data
{
    public class Publications
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid Author { get; set; }
        public DateTime CreationDate { get; set; }
        public int IsDeleted { get; set; }
    }
}
