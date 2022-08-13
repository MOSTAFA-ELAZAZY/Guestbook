using FluentValidation;
using Guestbook.Dto.Message;

namespace Guestbook.Validation.Message
{
    public class CreationMessageValidator : AbstractValidator<MessageForCreationDto>
    {
        public CreationMessageValidator()
        {
            RuleFor(t => t.Message).NotEmpty().WithMessage("Message Is required")
                .MinimumLength(1).WithMessage("Message Must Have Atlest 1 Chracter");

            RuleFor(s => s.IsReplay).LessThanOrEqualTo(1)
                .WithMessage("IsReplay Must be Less Than Or Equl 1")
                .GreaterThanOrEqualTo(0)
                .WithMessage("IsReplay Must be Greater Than Or Equl 0");


            RuleFor(s => s.MainMessageId).GreaterThan(0).When(s => s.IsReplay == 1)
                 .WithMessage("MainMessageId Is The Id Of Message You Replay In it " +
                 "  You Can't Add Replay When You set Replay = 0");


        }
    }
}
