using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Rules
{
    public class UserProfileSocialAccountBusinessRules
    {
        private readonly IUserProfileSocialAccountRepository _userProfileSocialAccountRepository;

        public UserProfileSocialAccountBusinessRules(IUserProfileSocialAccountRepository userProfileSocialAccountRepository)
        {
            _userProfileSocialAccountRepository = userProfileSocialAccountRepository;
        }

        public async Task UserProfileSocialAccountMustBeExist(int id)
        {
            UserProfileSocialAccount result = await _userProfileSocialAccountRepository.GetAsync(ptt => ptt.Id == id);
            if (result == null) throw new BusinessException("UserProfileSocialAccount Does Not Exist!");
        }
    }
}
