using FluentValidation;
using BWire.Core.Domain.Catalog;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Templates;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Templates
{
    public partial class ProductTemplateValidator : BaseNopValidator<ProductTemplateModel>
    {
        public ProductTemplateValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Product.ViewPath.Required"));

            SetDatabaseValidationRules<ProductTemplate>(dataProvider);
        }
    }
}