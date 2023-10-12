using FluentValidation;
using Store.Services.Dtos;

namespace Store.Services.Validator
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
