using FluentValidation;
using Store.Services.Dtos;

namespace Store.Services.Validator
{
    public class SaveCategoryDtoValidator : AbstractValidator<SaveCategoryDto>
    {
        public SaveCategoryDtoValidator()
        {
            RuleFor(x  => x.Name).NotEmpty()
                                .NotNull()
                                .MaximumLength(20);

            RuleFor(x => x.Description).NotEmpty()
                                    .NotNull()
                                    .MaximumLength(50);

        }

    }
}
