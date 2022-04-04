using FluentValidation;
using BWire.Core.Domain.Directory;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Directory;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Directory
{
    public partial class StateProvinceValidator : BaseNopValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));

            SetDatabaseValidationRules<StateProvince>(dataProvider);
        }
    }
}