using FluentValidation;
using BWire.Core.Domain.Orders;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Orders;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Orders
{
    public partial class CheckoutAttributeValueValidator : BaseNopValidator<CheckoutAttributeValueModel>
    {
        public CheckoutAttributeValueValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CheckoutAttributeValue>(dataProvider);
        }
    }
}