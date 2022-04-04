using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.Vendors;

namespace BWire.Web.Validators.Vendors
{
    public partial class VendorInfoValidator : BaseNopValidator<VendorInfoModel>
    {
        public VendorInfoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}