using FluentValidation;
using Store.Core.Modules.Products.Dtos;

namespace Store.Core.Modules.Products.Validators
{
    public class SaveProductDtoValidator : AbstractValidator<SaveProductDto>
    {
        public SaveProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .NotNull()
                                .MaximumLength(50);

            RuleFor(x => x.Description).NotEmpty()
                                       .NotNull();

            RuleFor(x => x.Price).NotEmpty()
                               .NotNull()
                               .GreaterThan(0);

            RuleFor(x => x.BrandId).NotEmpty()
                                   .NotNull()
                                   .GreaterThan(0);

            RuleFor(x => x.Stock).NotEmpty()
                               .NotNull()
                               .GreaterThan(0);
        }
    }
}
