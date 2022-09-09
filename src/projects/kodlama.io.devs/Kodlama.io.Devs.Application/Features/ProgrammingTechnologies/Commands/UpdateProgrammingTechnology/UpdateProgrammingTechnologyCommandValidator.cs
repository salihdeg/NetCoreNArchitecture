using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    public class UpdateProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdateProgrammingTechnologyCommandValidator()
        {
            RuleFor(p=> p.Id).NotEmpty();
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
            RuleFor(p => p.ProgrammingTechnologyTypeId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
