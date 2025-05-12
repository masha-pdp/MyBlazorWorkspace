using FluentValidation;
using BlazorAppWebAssembly.Features.Comments.DTO;


namespace BlazorAppWebAssembly.Features.Comments.Validators
{
    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(c => c.userid)
                .NotNull().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");
            
            RuleFor(c => c.text)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(300).WithMessage("Comment must not exceed 300 characters.");
        }
    }
}



