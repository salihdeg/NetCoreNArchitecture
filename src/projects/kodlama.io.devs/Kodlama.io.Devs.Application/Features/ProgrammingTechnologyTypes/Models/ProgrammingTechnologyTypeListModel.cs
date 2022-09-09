using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models
{
    public class ProgrammingTechnologyTypeListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyTypeListDto> Items { get; set; }
    }
}
