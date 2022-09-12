namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos
{
    public class DeletedUserProfileSocialAccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialPlatformId { get; set; }
        public string SocialPlatformURI { get; set; }
    }
}
