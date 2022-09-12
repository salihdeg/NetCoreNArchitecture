using AutoMapper;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public class CreateUserProfileCommand : IRequest<CreatedUserProfileDto>
    {
        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileDto>
        {
            private readonly IUserProfileRepository  _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<CreatedUserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = _mapper.Map<UserProfile>(request);
                UserProfile createdUserProfile = await _userProfileRepository.AddAsync(userProfile);

                CreatedUserProfileDto createdUserProfileDto = _mapper.Map<CreatedUserProfileDto>(createdUserProfile);

                return createdUserProfileDto;
            }
        }
    }
}
