using FluentValidation;
using Posts.Replies.Application.Commands;

namespace Posts.Replies.Application.Validators
{
    public class CreateReplyValidator : AbstractValidator<CreateReplyCommand>
    {
        public CreateReplyValidator()
        {
            RuleFor(r => r.Text)
                .NotNull()
                .WithMessage("{PropertyName} is required.")
                .MaximumLength(300)
                .WithMessage("{PropertyName} must be at most {MaxLength} characters long.");

            RuleFor(r => r.User)
                .NotNull()
                .WithMessage("{PropertyName} is required.");

            RuleFor(r => r.CommentId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }
}