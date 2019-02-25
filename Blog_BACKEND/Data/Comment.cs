namespace Blog_BACKEND.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PublicationId { get; set; }
        public int UserId { get; set; }
        public int CreationDate { get; set; }
        public int IsDeleted { get; set; }

        public User User { get; set; }

        public Publication Publication { get; set; }
    }
}
