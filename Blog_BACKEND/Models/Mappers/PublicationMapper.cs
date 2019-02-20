using Blog_BACKEND.Data;

namespace Blog_BACKEND.Models.Mappers
{
    public static class PublicationMapper
    {
        public static PublicationResponse ToResponseModel(Publication publication)
        {
            var result = new PublicationResponse
            {
                Id = publication.Id,
                Text = publication.Text,
                Title = publication.Title,
                CreationDate = publication.CreationDate,
                Author = new UserResponse
                {
                    Id = publication.User.Id,
                    FirstName = publication.User.FirstName,
                    LastName = publication.User.LastName
                }
            };
            
            return result;
        }
    }
}