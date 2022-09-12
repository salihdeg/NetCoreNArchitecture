using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Models
{
    public class UserProfileListModel : BasePageableModel
    {
        public IList<UserProfileListDto> Items { get; set; }
    }
}
