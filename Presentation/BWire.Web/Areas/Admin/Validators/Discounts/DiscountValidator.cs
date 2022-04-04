using FluentValidation;
using BWire.Core.Domain.Discounts;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Discounts;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Discounts
{
    public partial class DiscountValidator : BaseNopValidator<DiscountModel>
    {
        public DiscountValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.Discounts.Fields.Name.Required"));

            SetDatabaseValidationRules<Discount>(dataProvider);
        }
    }
}