using FluentValidation;
using Guestbook.Dto.user;

namespace Guestbook.Validation.User
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
             RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                    .EmailAddress().WithMessage("A valid email is required");

            RuleFor(s => s.Password).NotEmpty().WithMessage("PassWord is required")
                .MinimumLength(8).WithMessage("Password Must 8 or more letters ")
                .MaximumLength(100).WithMessage("Password Max Length is 100");
        }
    }
}
