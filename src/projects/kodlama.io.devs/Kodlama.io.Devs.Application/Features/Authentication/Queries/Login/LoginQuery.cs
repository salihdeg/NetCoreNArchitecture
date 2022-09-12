using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.Dtos;
using Kodlama.io.Devs.Application.Features.Authentication.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Kodlama.io.Devs.Application.Features.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<UserLoginDto>
    {
        public UserProfileForLoginDto UserProfileForLoginDto { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, UserLoginDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public LoginQueryHandler(IUserProfileRepository userProfileRepository, IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<UserLoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Email == request.UserProfileForLoginDto.Email);

                await _authenticationBusinessRules.UserProfileMustExist(userProfile);
                await _authenticationBusinessRules.UserPasswordMustBeCorrect(userProfile, request.UserProfileForLoginDto.Password);

                List<OperationClaim> userClaims = (await _userOperationClaimRepository.GetListAsync(u => u.UserId == userProfile.Id, include: p => p.Include(a => a.OperationClaim))).Items.Select(b => b.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(userProfile, userClaims);
                UserLoginDto userLoginDto = _mapper.Map<UserLoginDto>(accessToken);

                return userLoginDto;
            }
        }
    }
}
