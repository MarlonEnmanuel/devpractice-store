using FluentValidation;
using Store.Core.Dtos;

namespace Store.Core.Validator
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
