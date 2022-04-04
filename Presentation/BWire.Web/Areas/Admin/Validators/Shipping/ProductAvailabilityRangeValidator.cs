using FluentValidation;
using BWire.Core.Domain.Shipping;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Shipping;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Shipping
{
    public partial class ProductAvailabilityRangeValidator : BaseNopValidator<ProductAvailabilityRangeModel>
    {
        public ProductAvailabilityRangeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name.Required"));

            SetDatabaseValidationRules<ProductAvailabilityRange>(dataProvider);
        }
    }
}