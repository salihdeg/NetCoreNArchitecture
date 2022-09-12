using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<UpdatedUserProfileDto>
    {
        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDto>
        {
            private readonly IUserProfileRepository  _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UpdatedUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile updatedUserProfile = await _userProfileRepository.UpdateAsync(mappedUserProfile);

                UpdatedUserProfileDto updatedUserProfileDto = _mapper.Map<UpdatedUserProfileDto>(updatedUserProfile);
                return updatedUserProfileDto;
            }
        }
    }
}
