using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.Vendors;

namespace BWire.Web.Validators.Vendors
{
    public partial class ApplyVendorValidator : BaseNopValidator<ApplyVendorModel>
    {
        public ApplyVendorValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Vendors.ApplyAccount.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}