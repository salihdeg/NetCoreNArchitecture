using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform
{
    public class DeleteSocialPlatformCommandValidator : AbstractValidator<DeleteSocialPlatformCommand>
    {
        public DeleteSocialPlatformCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
        }
    }
}
