using FluentValidation;
using BWire.Core.Domain.Messages;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Messages;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Messages
{
    public partial class QueuedEmailValidator : BaseNopValidator<QueuedEmailModel>
    {
        public QueuedEmailValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.From).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.From.Required"));
            RuleFor(x => x.To).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.To.Required"));

            RuleFor(x => x.SentTries).NotNull().WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.SentTries.Required"))
                                    .InclusiveBetween(0, 99999).WithMessage(localizationService.GetResource("Admin.System.QueuedEmails.Fields.SentTries.Range"));

            SetDatabaseValidationRules<QueuedEmail>(dataProvider);

        }
    }
}