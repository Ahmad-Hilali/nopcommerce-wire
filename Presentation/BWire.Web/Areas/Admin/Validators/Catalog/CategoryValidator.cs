using FluentValidation;
using BWire.Core.Domain.Catalog;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Services.Seo;
using BWire.Web.Areas.Admin.Models.Catalog;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Catalog
{
    public partial class CategoryValidator : BaseNopValidator<CategoryModel>
    {
        public CategoryValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.Name.Required"));
            RuleFor(x => x.PageSizeOptions).Must(ValidatorUtilities.PageSizeOptionsValidator).WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.PageSizeOptions.ShouldHaveUniqueItems"));
            RuleFor(x => x.PageSize).Must((x, context) =>
            {
                if (!x.AllowCustomersToSelectPageSize && x.PageSize <= 0)
                    return false;

                return true;
            }).WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.PageSize.Positive"));
            RuleFor(x => x.SeName).Length(0, NopSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength));

            SetDatabaseValidationRules<Category>(dataProvider);
        }
    }
}