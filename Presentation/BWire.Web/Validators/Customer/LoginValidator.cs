using FluentValidation;
using BWire.Core.Domain.Customers;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.Customer;

namespace BWire.Web.Validators.Customer
{
    public partial class LoginValidator : BaseNopValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            if (!customerSettings.UsernamesEnabled)
            {
                //login by email
                RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.Login.Fields.Email.Required"));
                RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            }
        }
    }
}