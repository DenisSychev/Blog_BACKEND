namespace Blog_BACKEND.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreationDate { get; set; }
        public int LastLoginDate { get; set; }
    }
}