using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email alanı boş olamaz").EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır.");
            RuleFor(c => c.Age).NotEmpty().WithMessage("Age alanı boş olamaz").InclusiveBetween(18,60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");
        }
    }
}
