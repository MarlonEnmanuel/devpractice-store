using FluentValidation;
using Store.Core.Modules.Brands.Dtos;

namespace Store.Core.Modules.Brands.Validators
{
    public class SaveBrandDtoValidator : AbstractValidator<SaveBrandDto>
    {
        public SaveBrandDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}
