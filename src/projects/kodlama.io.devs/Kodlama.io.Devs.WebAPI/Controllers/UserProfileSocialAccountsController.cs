using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.CreateUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.DeleteUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Commands.UpdateUserProfileSocialAccount;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Dtos;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Models;
using Kodlama.io.Devs.Application.Features.UserProfileSocialAccounts.Queries.GetListUserProfileSocialAccountByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileSocialAccountsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserProfileSocialAccountCommand createUserProfileSocialAccountCommand)
        {
            CreatedUserProfileSocialAccountDto createdUserProfileSocialAccountDto = await Mediator.Send(createUserProfileSocialAccountCommand);
            return Ok(createdUserProfileSocialAccountDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileSocialAccountCommand updateUserProfileSocialAccountCommand)
        {
            UpdatedUserProfileSocialAccountDto updatedUserProfileSocialAccountDto = await Mediator.Send(updateUserProfileSocialAccountCommand);
            return Ok(updatedUserProfileSocialAccountDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProfileSocialAccountCommand deleteUserProfileSocialAccountCommand)
        {
            DeletedUserProfileSocialAccountDto result = await Mediator.Send(deleteUserProfileSocialAccountCommand);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListUserProfileSocialAccountByDynamicQuery getListUserProfileSocialAccountByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            UserProfileSocialAccountListModel result = await Mediator.Send(getListUserProfileSocialAccountByDynamicQuery);
            return Ok(result);
        }
    }
}
