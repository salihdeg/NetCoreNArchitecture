using Core.Security.JWT;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authentication.Dtos
{
    public class UserRegisterDto
    {
        //public UserProfile UserProfile { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
