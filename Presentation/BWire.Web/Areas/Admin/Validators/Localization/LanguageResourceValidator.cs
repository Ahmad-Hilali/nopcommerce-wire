using FluentValidation;
using BWire.Core.Domain.Localization;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Localization;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Localization
{
    public partial class LanguageResourceValidator : BaseNopValidator<LocaleResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            //if validation without this set rule is applied, in this case nothing will be validated
            //it's used to prevent auto-validation of child models
            RuleSet(NopValidatorDefaults.ValidationRuleSet, () =>
            {
                RuleFor(model => model.ResourceName)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));

                RuleFor(model => model.ResourceValue)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));

                SetDatabaseValidationRules<LocaleStringResource>(dataProvider);
            });
        }
    }
}