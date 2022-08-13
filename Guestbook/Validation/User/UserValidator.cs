using FluentValidation;
using Guestbook.Dto.user;

namespace Guestbook.Validation.User
{
    public class UserValidator : AbstractValidator<UserForCreationDto>
    {
        public UserValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Name Is required")
            .MinimumLength(3)
            .MaximumLength(25);

            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
