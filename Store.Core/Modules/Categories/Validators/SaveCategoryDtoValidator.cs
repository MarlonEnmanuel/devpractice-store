using FluentValidation;
using Store.Core.Modules.Categories.Dtos;

namespace Store.Core.Modules.Categories.Validators
{
    public class SaveCategoryDtoValidator : AbstractValidator<SaveCategoryDto>
    {
        public SaveCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Id).GreaterThan(0);
        }

    }
}
