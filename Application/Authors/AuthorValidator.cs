using Domain;
using FluentValidation;

namespace Application.Authors
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}