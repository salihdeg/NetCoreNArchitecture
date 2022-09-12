using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommand : IRequest<DeletedUserProfileDto>
    {
        public int Id { get; set; }
        public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileDto>
        {
            private readonly IUserProfileRepository  _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public DeleteUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<DeletedUserProfileDto> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = await _userProfileRepository.GetAsync(r => r.Id == request.Id);
                UserProfile deletedUserProfile = await _userProfileRepository.DeleteAsync(userProfile);

                DeletedUserProfileDto deletedUserProfileDto = _mapper.Map<DeletedUserProfileDto>(userProfile);

                return deletedUserProfileDto;
            }
        }
    }
}
