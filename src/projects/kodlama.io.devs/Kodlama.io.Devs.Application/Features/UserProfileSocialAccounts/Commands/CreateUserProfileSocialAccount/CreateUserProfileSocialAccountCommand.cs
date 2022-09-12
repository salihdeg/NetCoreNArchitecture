using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.CreateUserProfileSocialAccount
{
    public class CreateUserProfileSocialAccountCommand : IRequest<CreatedUserProfileSocialAccountDto>
    {
        public int UserId { get; set; }
        public string SocialPlatformId { get; set; }
        public string SocialPlatformURI { get; set; }

        public class CreateUserProfileSocialAccountCommandHandler : IRequestHandler<CreateUserProfileSocialAccountCommand, CreatedUserProfileSocialAccountDto>
        {
            private readonly IUserProfileSocialAccountRepository  _userProfileSocialAccountRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialAccountBusinessRules _userProfileSocialAccountBusinessRules;

            public CreateUserProfileSocialAccountCommandHandler(IUserProfileSocialAccountRepository userProfileSocialAccountRepository, IMapper mapper, UserProfileSocialAccountBusinessRules userProfileSocialAccountBusinessRules)
            {
                _userProfileSocialAccountRepository = userProfileSocialAccountRepository;
                _mapper = mapper;
                _userProfileSocialAccountBusinessRules = userProfileSocialAccountBusinessRules;
            }

            public async Task<CreatedUserProfileSocialAccountDto> Handle(CreateUserProfileSocialAccountCommand request, CancellationToken cancellationToken)
            {
                UserProfileSocialAccount userProfileSocialAccount = _mapper.Map<UserProfileSocialAccount>(request);
                UserProfileSocialAccount createdUserProfileSocialAccount = await _userProfileSocialAccountRepository.AddAsync(userProfileSocialAccount);

                CreatedUserProfileSocialAccountDto createdUserProfileSocialAccountDto = _mapper.Map<CreatedUserProfileSocialAccountDto>(createdUserProfileSocialAccount);

                return createdUserProfileSocialAccountDto;
            }
        }
    }
}
