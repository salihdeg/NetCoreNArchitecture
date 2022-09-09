using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType
{
    public class UpdateProgrammingTechnologyTypeCommandValidator : AbstractValidator<UpdateProgrammingTechnologyTypeCommand>
    {
        public UpdateProgrammingTechnologyTypeCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}
