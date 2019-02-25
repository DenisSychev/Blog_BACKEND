namespace Blog_BACKEND.Models
{
    public class PublicationResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CreationDate { get; set; }
        
        public UserResponse Author { get; set; }

        public CommentResponse Comment { get; set; }
    }
}