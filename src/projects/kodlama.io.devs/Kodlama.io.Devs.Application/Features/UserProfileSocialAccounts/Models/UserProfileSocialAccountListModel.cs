using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Models
{
    public class UserProfileSocialAccountListModel : BasePageableModel
    {
        public IList<UserProfileSocialAccountListDto> Items { get; set; }
    }
}
