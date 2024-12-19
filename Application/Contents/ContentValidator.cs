using FluentValidation;

namespace Application.Contents
{
    public class ContentValidator : AbstractValidator<ContentDto>
    {
        public ContentValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("name must not emtpy");
            RuleFor(c => c.ContentCategoryId).NotEmpty().WithMessage("ContentCategoryId must not emtpy");

        }
    }
}