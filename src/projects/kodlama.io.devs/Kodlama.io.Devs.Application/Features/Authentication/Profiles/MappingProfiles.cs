using AutoMapper;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authentication.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, UserProfileForRegisterDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileForLoginDto>().ReverseMap();
            CreateMap<UserRegisterDto, AccessToken>().ReverseMap();
            CreateMap<UserLoginDto, AccessToken>().ReverseMap();
        }
    }
}
