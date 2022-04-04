using FluentValidation;
using BWire.Core.Domain.Topics;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Services.Seo;
using BWire.Web.Areas.Admin.Models.Topics;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Topics
{
    public partial class TopicValidator : BaseNopValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.SeName)
                .Length(0, NopSeoDefaults.ForumTopicLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.ForumTopicLength));

            RuleFor(x => x.Password)
                .NotEmpty()
                .When(x => x.IsPasswordProtected)
                .WithMessage(localizationService.GetResource("Validation.Password.IsNotEmpty"));

            SetDatabaseValidationRules<Topic>(dataProvider);
        }
    }
}
