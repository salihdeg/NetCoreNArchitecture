using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.CreateUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.DeleteUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.UpdateUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfileSocialAccount, CreateUserProfileSocialAccountCommand>().ReverseMap();
            CreateMap<UserProfileSocialAccount, UpdateUserProfileSocialAccountCommand>().ReverseMap();
            CreateMap<UserProfileSocialAccount, DeleteUserProfileSocialAccountCommand>().ReverseMap();

            CreateMap<UserProfileSocialAccount, CreatedUserProfileSocialAccountDto>().ReverseMap();
            CreateMap<UserProfileSocialAccount, UpdatedUserProfileSocialAccountDto>().ReverseMap();
            CreateMap<UserProfileSocialAccount, DeletedUserProfileSocialAccountDto>().ReverseMap();

            CreateMap<UserProfileSocialAccount, UserProfileSocialAccountListDto>().ReverseMap();
            CreateMap<IPaginate<UserProfileSocialAccount>, UserProfileSocialAccountListModel>().ReverseMap();
        }
    }
}
