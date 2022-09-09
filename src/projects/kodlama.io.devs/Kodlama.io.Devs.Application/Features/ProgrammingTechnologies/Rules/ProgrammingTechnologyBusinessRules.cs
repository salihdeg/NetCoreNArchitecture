using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologyBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologyBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(ptt => ptt.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Technology Exist!");
        }

        public async Task<ProgrammingTechnology> ProgrammingTechnologyMustBeExist(int id)
        {
            ProgrammingTechnology result = await _programmingTechnologyRepository.GetAsync(ptt => ptt.Id == id, enableTracking: false);
            if (result == null) throw new BusinessException("Programming Technology Does Not Exist!");
            else return result;
        }

        public void ProgrammingTechnologyMustBeExist(ProgrammingTechnology programmingTechnology)
        {
            if(programmingTechnology == null) throw new BusinessException("Programming Technology Does Not Exist!");
        }
    }
}
