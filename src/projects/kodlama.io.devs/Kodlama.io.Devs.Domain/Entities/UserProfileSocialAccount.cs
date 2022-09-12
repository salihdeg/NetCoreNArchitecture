using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class UserProfileSocialAccount : Entity
    {
        public int UserId { get; set; }
        public int SocialPlatformId { get; set; }
        public string SocialPlatformURI { get; set; }
        public virtual UserProfile? UserProfile { get; set; }
        public virtual SocialPlatform? SocialPlatform { get; set; }

        public UserProfileSocialAccount()
        {

        }

        public UserProfileSocialAccount(int id, int userId, int socialPlatformId, string socialPlatformURI) : this()
        {
            Id = id;
            UserId = userId;
            SocialPlatformId = socialPlatformId;
            SocialPlatformURI = socialPlatformURI;
        }
    }
}
