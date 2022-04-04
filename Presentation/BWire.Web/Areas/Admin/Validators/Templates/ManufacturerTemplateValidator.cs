using FluentValidation;
using BWire.Core.Domain.Catalog;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Templates;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Templates
{
    public partial class ManufacturerTemplateValidator : BaseNopValidator<ManufacturerTemplateModel>
    {
        public ManufacturerTemplateValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Manufacturer.ViewPath.Required"));

            SetDatabaseValidationRules<ManufacturerTemplate>(dataProvider);
        }
    }
}