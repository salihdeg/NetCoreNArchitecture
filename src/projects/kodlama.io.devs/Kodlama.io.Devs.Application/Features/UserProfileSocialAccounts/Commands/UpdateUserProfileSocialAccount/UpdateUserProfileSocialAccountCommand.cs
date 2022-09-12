using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.UpdateUserProfileSocialAccount
{
    public class UpdateUserProfileSocialAccountCommand : IRequest<UpdatedUserProfileSocialAccountDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialPlatformId { get; set; }
        public string SocialPlatformURI { get; set; }

        public class UpdateUserProfileSocialAccountCommandHandler : IRequestHandler<UpdateUserProfileSocialAccountCommand, UpdatedUserProfileSocialAccountDto>
        {
            private readonly IUserProfileSocialAccountRepository  _userProfileSocialAccountRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialAccountBusinessRules _userProfileSocialAccountBusinessRules;

            public UpdateUserProfileSocialAccountCommandHandler(IUserProfileSocialAccountRepository userProfileSocialAccountRepository, IMapper mapper, UserProfileSocialAccountBusinessRules userProfileSocialAccountBusinessRules)
            {
                _userProfileSocialAccountRepository = userProfileSocialAccountRepository;
                _mapper = mapper;
                _userProfileSocialAccountBusinessRules = userProfileSocialAccountBusinessRules;
            }

            public async Task<UpdatedUserProfileSocialAccountDto> Handle(UpdateUserProfileSocialAccountCommand request, CancellationToken cancellationToken)
            {
                await _userProfileSocialAccountBusinessRules.UserProfileSocialAccountMustBeExist(request.Id);

                UserProfileSocialAccount mappedUserProfileSocialAccount = _mapper.Map<UserProfileSocialAccount>(request);
                UserProfileSocialAccount updatedUserProfileSocialAccount = await _userProfileSocialAccountRepository.UpdateAsync(mappedUserProfileSocialAccount);

                UpdatedUserProfileSocialAccountDto updatedUserProfileSocialAccountDto = _mapper.Map<UpdatedUserProfileSocialAccountDto>(updatedUserProfileSocialAccount);
                return updatedUserProfileSocialAccountDto;
            }
        }
    }
}
