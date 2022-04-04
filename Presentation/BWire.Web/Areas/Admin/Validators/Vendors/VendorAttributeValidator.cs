using FluentValidation;
using BWire.Core.Domain.Vendors;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Vendors;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Vendors
{
    public partial class VendorAttributeValidator : BaseNopValidator<VendorAttributeModel>
    {
        public VendorAttributeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Vendors.VendorAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<VendorAttribute>(dataProvider);
        }
    }
}