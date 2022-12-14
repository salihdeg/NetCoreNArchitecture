using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommandValidator : AbstractValidator<DeleteProgrammingTechnologyCommand>
    {
        public DeleteProgrammingTechnologyCommandValidator()
        {
            RuleFor(p=> p.Id).NotEmpty();
        }
    }
}
