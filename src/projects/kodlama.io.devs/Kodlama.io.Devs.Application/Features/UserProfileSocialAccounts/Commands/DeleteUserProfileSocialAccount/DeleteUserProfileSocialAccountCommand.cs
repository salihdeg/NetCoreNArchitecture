using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.DeleteUserProfileSocialAccount
{
    public class DeleteUserProfileSocialAccountCommand : IRequest<DeletedUserProfileSocialAccountDto>
    {
        public int Id { get; set; }

        public class DeleteUserProfileSocialAccountCommandHandler : IRequestHandler<DeleteUserProfileSocialAccountCommand, DeletedUserProfileSocialAccountDto>
        {
            private readonly IUserProfileSocialAccountRepository  _userProfileSocialAccountRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileSocialAccountBusinessRules _userProfileSocialAccountBusinessRules;

            public DeleteUserProfileSocialAccountCommandHandler(IUserProfileSocialAccountRepository userProfileSocialAccountRepository, IMapper mapper, UserProfileSocialAccountBusinessRules userProfileSocialAccountBusinessRules)
            {
                _userProfileSocialAccountRepository = userProfileSocialAccountRepository;
                _mapper = mapper;
                _userProfileSocialAccountBusinessRules = userProfileSocialAccountBusinessRules;
            }

            public async Task<DeletedUserProfileSocialAccountDto> Handle(DeleteUserProfileSocialAccountCommand request, CancellationToken cancellationToken)
            {
                await _userProfileSocialAccountBusinessRules.UserProfileSocialAccountMustBeExist(request.Id);

                UserProfileSocialAccount userProfileSocialAccount = await _userProfileSocialAccountRepository.GetAsync(r => r.Id == request.Id);

                UserProfileSocialAccount deletedUserProfileSocialAccount = await _userProfileSocialAccountRepository.DeleteAsync(userProfileSocialAccount);

                DeletedUserProfileSocialAccountDto deletedUserProfileSocialAccountDto = _mapper.Map<DeletedUserProfileSocialAccountDto>(userProfileSocialAccount);

                return deletedUserProfileSocialAccountDto;
            }
        }
    }
}
