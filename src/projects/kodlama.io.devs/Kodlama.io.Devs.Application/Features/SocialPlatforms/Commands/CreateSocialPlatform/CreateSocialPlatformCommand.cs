using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform
{
    public class CreateSocialPlatformCommand : IRequest<CreatedSocialPlatformDto>
    {
        public string Name { get; set; }
        public string DomainAddress { get; set; }

        public class CreateSocialPlatformCommandHandler : IRequestHandler<CreateSocialPlatformCommand, CreatedSocialPlatformDto>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;

            public CreateSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialPlatformDto> Handle(CreateSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                SocialPlatform mappedSocialPlatform = _mapper.Map<SocialPlatform>(request);
                SocialPlatform socialPlatform = await _socialPlatformRepository.AddAsync(mappedSocialPlatform);

                CreatedSocialPlatformDto createdSocialPlatformDto = _mapper.Map<CreatedSocialPlatformDto>(socialPlatform);
                return createdSocialPlatformDto;
            }
        }
    }
}
