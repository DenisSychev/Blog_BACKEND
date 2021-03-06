﻿using System.Collections.Generic;

namespace Blog_BACKEND.Data
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int CreationDate { get; set; }
        public int IsDeleted { get; set; }

        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    } 
}
