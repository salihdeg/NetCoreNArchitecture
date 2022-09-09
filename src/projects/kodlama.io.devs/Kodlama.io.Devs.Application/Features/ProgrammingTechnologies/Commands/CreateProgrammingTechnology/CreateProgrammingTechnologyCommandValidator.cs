using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreateProgrammingTechnologyCommandValidator()
        {
            RuleFor(p=> p.Name).NotEmpty();
            RuleFor(p => p.ProgrammingLanguageId).NotEmpty();
            RuleFor(p => p.ProgrammingTechnologyTypeId).NotEmpty();
        }
    }
}
