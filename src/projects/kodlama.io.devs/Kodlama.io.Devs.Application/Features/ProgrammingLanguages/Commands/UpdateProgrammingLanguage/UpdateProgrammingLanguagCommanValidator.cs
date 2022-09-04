using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguagCommanValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguagCommanValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();
        }
    }
}
