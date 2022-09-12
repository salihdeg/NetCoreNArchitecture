using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authentication.Dtos;
using Kodlama.io.Devs.Application.Features.Authentication.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<UserRegisterDto>
    {
        public UserProfileForRegisterDto UserProfileForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserRegisterDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public RegisterCommandHandler(IUserProfileRepository userProfileRepository, IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository, ITokenHelper tokenHelper, IMapper mapper, AuthenticationBusinessRules authenticationBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _operationClaimRepository = operationClaimRepository;
                _tokenHelper = tokenHelper;
                _mapper = mapper;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<UserRegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authenticationBusinessRules.UserEmailMustBeUniqueWhenInsterted(request.UserProfileForRegisterDto.Email);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request.UserProfileForRegisterDto);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserProfileForRegisterDto.Password,out passwordHash, out passwordSalt);

                mappedUserProfile.PasswordSalt = passwordSalt;
                mappedUserProfile.PasswordHash = passwordHash;
                mappedUserProfile.Status = true;

                UserProfile createdUser = await _userProfileRepository.AddAsync(mappedUserProfile);

                const string defaultUserClaimName = "User";
                OperationClaim? userClaim = await _operationClaimRepository.GetAsync(o=> o.Name == defaultUserClaimName);

                List<OperationClaim> userClaims = (await _userOperationClaimRepository.GetListAsync(o=> o.UserId == createdUser.Id)).Items.Select(o => o.OperationClaim).ToList();

                AccessToken accessToken = _tokenHelper.CreateToken(createdUser, userClaims);

                UserRegisterDto userRegisterDto = _mapper.Map<UserRegisterDto>(accessToken);
                return userRegisterDto;
            }
        }
    }
}
