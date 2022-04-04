using FluentValidation;
using BWire.Core.Domain.Shipping;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Shipping;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Shipping
{
    public partial class DeliveryDateValidator : BaseNopValidator<DeliveryDateModel>
    {
        public DeliveryDateValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.DeliveryDates.Fields.Name.Required"));

            SetDatabaseValidationRules<DeliveryDate>(dataProvider);
        }
    }
}