using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage => "{PropertyName} alanı boş olamaz";
        public AddressValidator()
        {
            RuleFor(a => a.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(a => a.Province).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(a => a.PostCode).NotEmpty().WithMessage(NotEmptyMessage).MaximumLength(5).WithMessage("{PropertyName} alanı en fazla {MaxLength} karakter olmalıdır.");
        }
    }
}
