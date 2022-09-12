using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class UserProfile : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AccountCreateTime { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual ICollection<UserProfileSocialAccount> UserProfileSocialAccounts { get; set; }

        public UserProfile()
        {

        }

        public UserProfile(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType, DateTime dateOfBirth) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            AuthenticatorType = authenticatorType;
            DateOfBirth = dateOfBirth;
            AccountCreateTime = DateTime.Now;
            LastLogin = DateTime.Now;
        }
    }
}
