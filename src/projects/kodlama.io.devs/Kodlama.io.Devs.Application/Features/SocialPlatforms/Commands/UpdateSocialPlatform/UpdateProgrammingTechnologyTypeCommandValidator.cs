using FluentValidation;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType
{
    public class UpdateSocialPlatformCommandValidator : AbstractValidator<UpdateSocialPlatformCommand>
    {
        public UpdateSocialPlatformCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty();
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}
