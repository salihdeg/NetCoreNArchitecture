using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exist.");
        }

        public async Task ProgrammingLanguageShouldBeExist(int id)
        {
            ProgrammingLanguage result = await _programmingLanguageRepository.GetAsync(pl => pl.Id == id);
            if (result == null) throw new BusinessException("Programming Language does not exist.");
        }

        public async Task ProgrammingLanguageShouldBeExist(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Programming Language does not exist.");
        }
    }
}
