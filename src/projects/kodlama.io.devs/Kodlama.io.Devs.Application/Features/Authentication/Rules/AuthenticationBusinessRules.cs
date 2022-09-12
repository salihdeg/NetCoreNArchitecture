using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authentication.Rules
{
    public class AuthenticationBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;

        public AuthenticationBusinessRules(IUserProfileRepository userProfileRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userProfileRepository = userProfileRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task UserEmailMustBeUniqueWhenInsterted(string email)
        {
            UserProfile? result = await _userProfileRepository.GetAsync(u => u.Email == email);
            if (result != null) throw new BusinessException("This Email Already Registered");
        }

        public async Task UserProfileMustExist(User? user)
        {
            if (user == null) throw new BusinessException("There Is No User!");
        }

        public async Task UserPasswordMustBeCorrect(User user, string password)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if(!result) throw new BusinessException("Wrong Password!");
        }
    }
}
