using FluentValidation;
using BWire.Core.Domain.Customers;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.Customer;

namespace BWire.Web.Validators.Customer
{
    public partial class PasswordRecoveryConfirmValidator : BaseNopValidator<PasswordRecoveryConfirmModel>
    {
        public PasswordRecoveryConfirmValidator(ILocalizationService localizationService, CustomerSettings customerSettings)
        {
            RuleFor(x => x.NewPassword).IsPassword(localizationService, customerSettings);            
            RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.ConfirmNewPassword.Required"));
            RuleFor(x => x.ConfirmNewPassword).Equal(x => x.NewPassword).WithMessage(localizationService.GetResource("Account.PasswordRecovery.NewPassword.EnteredPasswordsDoNotMatch"));
        }
    }
}