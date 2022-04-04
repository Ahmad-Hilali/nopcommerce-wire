using FluentValidation;
using BWire.Core.Domain.Directory;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Directory;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Directory
{
    public partial class MeasureDimensionValidator : BaseNopValidator<MeasureDimensionModel>
    {
        public MeasureDimensionValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name.Required"));
            RuleFor(x => x.SystemKeyword).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword.Required"));

            SetDatabaseValidationRules<MeasureDimension>(dataProvider);
        }
    }
}