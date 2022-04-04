using FluentValidation;
using BWire.Core.Domain.Customers;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Customers;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Customers
{
    public partial class CustomerAttributeValidator : BaseNopValidator<CustomerAttributeModel>
    {
        public CustomerAttributeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Customers.CustomerAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<CustomerAttribute>(dataProvider);
        }
    }
}