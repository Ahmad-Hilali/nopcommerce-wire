using FluentValidation;
using BWire.Core.Domain.Gdpr;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Settings;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Settings
{
    public partial class GdprConsentValidator : BaseNopValidator<GdprConsentModel>
    {
        public GdprConsentValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.Message.Required"));
            RuleFor(x => x.RequiredMessage)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage.Required"))
                .When(x => x.IsRequired);

            SetDatabaseValidationRules<GdprConsent>(dataProvider);
        }
    }
}