using FluentValidation;
using BWire.Core.Domain.Tax;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Tax;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Tax
{
    public partial class TaxCategoryValidator : BaseNopValidator<TaxCategoryModel>
    {
        public TaxCategoryValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Tax.Categories.Fields.Name.Required"));

            SetDatabaseValidationRules<TaxCategory>(dataProvider);
        }
    }
}