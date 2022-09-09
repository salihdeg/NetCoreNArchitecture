using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetListProgrammingTechnologyType;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologyTypesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyTypeCommand createProgrammingTechnologyTypeCommand)
        {
            CreatedProgrammingTechnologyTypeDto result = await Mediator.Send(createProgrammingTechnologyTypeCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyTypeCommand updateProgrammingTechnologyTypeCommand)
        {
            UpdatedProgrammingTechnologyTypeDto result = await Mediator.Send(updateProgrammingTechnologyTypeCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyTypeCommand deleteProgrammingTechnologyTypeCommand)
        {
            DeletedProgrammingTechnologyTypeDto result = await Mediator.Send(deleteProgrammingTechnologyTypeCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyTypeQuery getListProgrammingTechnologyTypeQuery = new() { PageRequest = pageRequest };
            ProgrammingTechnologyTypeListModel result = await Mediator.Send(getListProgrammingTechnologyTypeQuery);

            return Ok(result);
        }
    }
}
