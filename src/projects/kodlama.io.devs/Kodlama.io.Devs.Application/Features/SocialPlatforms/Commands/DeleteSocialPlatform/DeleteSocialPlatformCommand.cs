using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform
{
    public class DeleteSocialPlatformCommand : IRequest<DeletedSocialPlatformDto>
    {
        public int Id { get; set; }

        public class DeleteSocialPlatformCommandHandler : IRequestHandler<DeleteSocialPlatformCommand, DeletedSocialPlatformDto>
        {
            private readonly ISocialPlatformRepository _socialPlatformRepository;
            private readonly IMapper _mapper;

            public DeleteSocialPlatformCommandHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper)
            {
                _socialPlatformRepository = socialPlatformRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialPlatformDto> Handle(DeleteSocialPlatformCommand request, CancellationToken cancellationToken)
            {
                SocialPlatform socialPlatform = await _socialPlatformRepository.GetAsync(p => p.Id == request.Id);

                DeletedSocialPlatformDto deletedSocialPlatformDto = _mapper.Map<DeletedSocialPlatformDto>(socialPlatform);
                return deletedSocialPlatformDto;
            }
        }
    }
}
