using Domain;
using FluentValidation;

namespace Application.Banners
{
    public class BannerValidator : AbstractValidator<BannerDto>
    {
        public BannerValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            // RuleFor(c => c.Photos).NotEmpty();
        }

    }
}