using FluentValidation;
using BWire.Core.Domain.Customers;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Customers;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerAttributeValueValidator : BaseNopValidator<CustomerAttributeValueModel>
    {
        public CustomerAttributeValueValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Values.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttributeValue>(dataProvider);
        }
    }
}