using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Queries.GetListUserProfileSocialAccountByDynamic
{
    public class GetListUserProfileSocialAccountByDynamicQuery : IRequest<UserProfileSocialAccountListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListUserProfileSocialAccountByDynamicQueryHandler : IRequestHandler<GetListUserProfileSocialAccountByDynamicQuery, UserProfileSocialAccountListModel>
        {
            private readonly IUserProfileSocialAccountRepository _userProfileSocialAccountRepository;
            private readonly IMapper _mapper;

            public GetListUserProfileSocialAccountByDynamicQueryHandler(IUserProfileSocialAccountRepository userProfileSocialAccountRepository, IMapper mapper)
            {
                _userProfileSocialAccountRepository = userProfileSocialAccountRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileSocialAccountListModel> Handle(GetListUserProfileSocialAccountByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserProfileSocialAccount> userProfileSocialAccounts = await _userProfileSocialAccountRepository.
                    GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: p => p.Include(opt => opt.SocialPlatform).Include(a => a.UserProfile),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                UserProfileSocialAccountListModel userProfileSocialAccountListModel = _mapper.Map<UserProfileSocialAccountListModel>(userProfileSocialAccounts);
                return userProfileSocialAccountListModel;
            }
        }
    }
}
