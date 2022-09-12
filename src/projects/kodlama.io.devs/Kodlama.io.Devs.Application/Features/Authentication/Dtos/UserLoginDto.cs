namespace Kodlama.io.Devs.Application.Features.Authentication.Dtos
{
    public class UserLoginDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
