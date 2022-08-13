using FluentValidation;
using Guestbook.Dto.Message;

namespace Guestbook.Validation.Message
{
    public class EditMessageValidator : AbstractValidator<MessageForEditDto>
    {
        public EditMessageValidator()
        {
            RuleFor(t => t.Message).NotEmpty().WithMessage("Message Is required")
                .MinimumLength(1).WithMessage("Message Must Have Atlest 1 Chracter");

            RuleFor(u => u.UserId).NotNull().WithMessage("UserId Is required")
                .GreaterThanOrEqualTo(1).WithMessage("User ID Must Greater than 0");

        }
    }
}
