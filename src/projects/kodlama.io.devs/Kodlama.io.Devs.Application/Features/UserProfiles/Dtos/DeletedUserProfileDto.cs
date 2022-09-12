namespace Kodlama.io.Devs.Application.Features.UserProfiles.Dtos
{
    public class DeletedUserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AccountCreateTime { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
