using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage => "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(c => c.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır.");
            RuleFor(c => c.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");

            RuleFor(c => c.BirthDate).NotEmpty().WithMessage(NotEmptyMessage).Must(b =>
            {
                return DateTime.Now.AddYears(-18) >= b;
            }).WithMessage("Yaşınız 18'den büyük olmalıdır.");

            RuleForEach(c => c.Addresses).SetValidator(new AddressValidator());
        }
    }
}
