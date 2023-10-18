using FluentValidation;
using Store.Core.Modules.Suppliers.Dtos;

namespace Store.Core.Modules.Suppliers.Validators
{
    public class SaveSupplierDtoValidator : AbstractValidator<SaveSupplierDto>
    {
        public SaveSupplierDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.RucSupplier)
                .NotNull()
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(11);

            RuleFor(x => x.BusinessName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }
}
