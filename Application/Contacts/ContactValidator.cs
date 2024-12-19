using Domain;
using FluentValidation;

namespace Application.Contacts
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}