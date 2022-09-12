using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();

            CreateMap<UserProfile, CreatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, DeletedUserProfileDto>().ReverseMap();

            CreateMap<UserProfile, UserProfileListDto>().ReverseMap();
            CreateMap<IPaginate<UserProfile>, UserProfileListModel>().ReverseMap();
        }
    }
}
