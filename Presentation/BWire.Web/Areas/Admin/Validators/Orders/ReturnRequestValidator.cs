using FluentValidation;
using BWire.Core.Domain.Orders;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Orders;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestValidator : BaseNopValidator<ReturnRequestModel>
    {
        public ReturnRequestValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.ReasonForReturn).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.ReasonForReturn.Required"));
            RuleFor(x => x.RequestedAction).NotEmpty().WithMessage(localizationService.GetResource("Admin.ReturnRequests.Fields.RequestedAction.Required"));

            SetDatabaseValidationRules<ReturnRequest>(dataProvider);
        }
    }
}