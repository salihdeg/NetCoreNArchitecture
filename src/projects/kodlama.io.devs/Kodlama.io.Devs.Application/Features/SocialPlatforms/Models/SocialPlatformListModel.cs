using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Models
{
    public class SocialPlatformListModel : BasePageableModel
    {
        public IList<SocialPlatformListDto> Items { get; set; }
    }
}