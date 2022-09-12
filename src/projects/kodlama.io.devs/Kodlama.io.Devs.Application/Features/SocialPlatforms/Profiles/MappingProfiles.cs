using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialPlatform, CreateSocialPlatformCommand>().ReverseMap();
            CreateMap<SocialPlatform, UpdateSocialPlatformCommand>().ReverseMap();
            CreateMap<SocialPlatform, DeleteSocialPlatformCommand>().ReverseMap();

            CreateMap<SocialPlatform, CreatedSocialPlatformDto>().ReverseMap();
            CreateMap<SocialPlatform, UpdatedSocialPlatformDto>().ReverseMap();
            CreateMap<SocialPlatform, DeletedSocialPlatformDto>().ReverseMap();

            CreateMap<SocialPlatform, SocialPlatformListDto>().ReverseMap();
            CreateMap<IPaginate<SocialPlatform>, SocialPlatformListModel>().ReverseMap();
        }
    }
}
