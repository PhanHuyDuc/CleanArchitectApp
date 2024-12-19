using Domain;
using FluentValidation;

namespace Application.Menus
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(u => u.MenuName).NotEmpty().WithMessage("Menu Name must not empty");
            RuleFor(u => u.MenuCategoryId).NotEmpty().WithMessage("Meny Cat must not empty");
        }
    }
}