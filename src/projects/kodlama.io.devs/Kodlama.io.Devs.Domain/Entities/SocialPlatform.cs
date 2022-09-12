using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class SocialPlatform : Entity
    {
        public string Name { get; set; }
        public string DomainAddress { get; set; }
        public virtual ICollection<UserProfileSocialAccount> UserProfileSocialAccounts { get; set; }

        public SocialPlatform()
        {
        }

        public SocialPlatform(int id, string name, string domainAddress) : this()
        {
            Id = id;
            Name = name;
            DomainAddress = domainAddress;
        }
    }
}
