using Core.Security.Dtos;

namespace Kodlama.io.Devs.Application.Features.Authentication.Dtos
{
    public class UserProfileForRegisterDto : UserForRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
