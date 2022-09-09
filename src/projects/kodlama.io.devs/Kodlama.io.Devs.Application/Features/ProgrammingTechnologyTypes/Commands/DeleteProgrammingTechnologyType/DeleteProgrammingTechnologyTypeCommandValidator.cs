using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType
{
    public class DeleteProgrammingTechnologyTypeCommandValidator : AbstractValidator<DeleteProgrammingTechnologyTypeCommand>
    {
        public DeleteProgrammingTechnologyTypeCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
