using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Dtos;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Models;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Queries.GetListSocialPlatform;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPlatformsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialPlatformCommand createSocialPlatformCommand)
        {
            CreatedSocialPlatformDto result = await Mediator.Send(createSocialPlatformCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialPlatformCommand updateSocialPlatformCommand)
        {
            UpdatedSocialPlatformDto result = await Mediator.Send(updateSocialPlatformCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialPlatformCommand deleteSocialPlatformCommand)
        {
            DeletedSocialPlatformDto result = await Mediator.Send(deleteSocialPlatformCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialPlatformQuery getListSocialPlatformQuery = new() { PageRequest = pageRequest };
            SocialPlatformListModel result = await Mediator.Send(getListSocialPlatformQuery);

            return Ok(result);
        }

        /*[HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingTechnologyByDynamicQuery getListProgrammingTechnologyByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyByDynamicQuery);
            return Ok(result);
        }*/
    }
}
