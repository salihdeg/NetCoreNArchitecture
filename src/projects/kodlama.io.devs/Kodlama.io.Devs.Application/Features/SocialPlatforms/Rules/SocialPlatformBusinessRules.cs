using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules
{
    public class SocialPlatformBusinessRules
    {
        private readonly ISocialPlatformRepository _socialPlatformRepository;

        public SocialPlatformBusinessRules(ISocialPlatformRepository socialPlatformRepository)
        {
            _socialPlatformRepository = socialPlatformRepository;
        }

        public async Task SocialPlatformNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SocialPlatform> result = await _socialPlatformRepository.GetListAsync(ptt => ptt.Name == name);
            if (result.Items.Any()) throw new BusinessException("Social Platform Type Exist!");
        }

        public async Task SocialPlatformMustBeExist(int id)
        {
            SocialPlatform result = await _socialPlatformRepository.GetAsync(ptt => ptt.Id == id);
            if (result == null) throw new BusinessException("Social Platform Does Not Exist!");
        }
    }
}
