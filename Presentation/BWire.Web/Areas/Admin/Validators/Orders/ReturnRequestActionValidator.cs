using FluentValidation;
using BWire.Core.Domain.Orders;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Orders;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestActionValidator : BaseNopValidator<ReturnRequestActionModel>
    {
        public ReturnRequestActionValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Order.ReturnRequestActions.Name.Required"));

            SetDatabaseValidationRules<ReturnRequestAction>(dataProvider);
        }
    }
}