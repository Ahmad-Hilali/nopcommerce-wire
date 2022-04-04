using FluentValidation;
using BWire.Core.Domain.Configuration;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Settings;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Settings
{
    public partial class SettingValidator : BaseNopValidator<SettingModel>
    {
        public SettingValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.AllSettings.Fields.Name.Required"));

            SetDatabaseValidationRules<Setting>(dataProvider);
        }
    }
}