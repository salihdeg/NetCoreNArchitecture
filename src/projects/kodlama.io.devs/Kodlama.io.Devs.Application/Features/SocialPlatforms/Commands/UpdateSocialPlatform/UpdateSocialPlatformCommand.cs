using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform
{
    public class UpdateSocialPlatformCommand : IRequest<UpdatedSocialPlatformDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DomainAddress { get; set; }

        public class UpdateSocialPlatformCommandHandler : IRequestHandler<UpdateSocialPlatformCommand, UpdatedSocialPlatformDto>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;
            private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

            public UpdateSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper, SocialPlatformBusinessRules socialPlatformBusinessRules)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
                _socialPlatformBusinessRules = socialPlatformBusinessRules;
            }

            public async Task<UpdatedSocialPlatformDto> Handle(UpdateSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                await _socialPlatformBusinessRules.SocialPlatformNameCanNotBeDuplicatedWhenInserted(request.Name);
                await _socialPlatformBusinessRules.SocialPlatformMustBeExist(request.Id);

                SocialPlatform mappedSocialPlatform = _mapper.Map<SocialPlatform>(request);
                SocialPlatform updatedSocialPlatform = await _socialPlatformRepository.UpdateAsync(mappedSocialPlatform);

                UpdatedSocialPlatformDto updatedSocialPlatformDto = _mapper.Map<UpdatedSocialPlatformDto>(updatedSocialPlatform);
                return updatedSocialPlatformDto;
            }
        }
    }
}
