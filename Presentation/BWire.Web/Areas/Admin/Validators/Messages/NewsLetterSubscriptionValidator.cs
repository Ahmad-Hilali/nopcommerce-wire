using FluentValidation;
using BWire.Core.Domain.Messages;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Messages;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Messages
{
    public partial class NewsLetterSubscriptionValidator : BaseNopValidator<NewsletterSubscriptionModel>
    {
        public NewsLetterSubscriptionValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Admin.Promotions.NewsLetterSubscriptions.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));

            SetDatabaseValidationRules<NewsLetterSubscription>(dataProvider);
        }
    }
}