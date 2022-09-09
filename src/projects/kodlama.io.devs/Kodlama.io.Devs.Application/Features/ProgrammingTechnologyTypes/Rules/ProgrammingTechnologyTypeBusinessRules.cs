using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules
{
    public class ProgrammingTechnologyTypeBusinessRules
    {
        private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;

        public ProgrammingTechnologyTypeBusinessRules(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository)
        {
            _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
        }

        public async Task ProgrammingTechnologyTypeNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnologyType> result = await _programmingTechnologyTypeRepository.GetListAsync(ptt => ptt.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Technology Type Exist!");
        }

        public async Task ProgrammingTechnologyTypeMustBeExist(int id)
        {
            ProgrammingTechnologyType result = await _programmingTechnologyTypeRepository.GetAsync(ptt => ptt.Id == id);
            if (result == null) throw new BusinessException("Programming Technology Type Does Not Exist!");
        }
    }
}
