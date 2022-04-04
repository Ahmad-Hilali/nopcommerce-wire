using FluentValidation;
using BWire.Core.Domain.Vendors;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Vendors;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Vendors
{
    public partial class VendorAttributeValueValidator : BaseNopValidator<VendorAttributeValueModel>
    {
        public VendorAttributeValueValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.VendorAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<VendorAttributeValue>(dataProvider);
        }
    }
}