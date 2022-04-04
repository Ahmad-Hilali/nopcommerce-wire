using FluentValidation;
using BWire.Core.Domain.Catalog;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Catalog;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Catalog
{
    /// <summary>
    /// Represent a review type validator
    /// </summary>
    public partial class ReviewTypeValidator : BaseNopValidator<ReviewTypeModel>
    {
        public ReviewTypeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Name.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Admin.Settings.ReviewType.Fields.Description.Required"));

            SetDatabaseValidationRules<ReviewType>(dataProvider);
        }
    }
}
