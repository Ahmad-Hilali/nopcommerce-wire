using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.PrivateMessages;

namespace BWire.Web.Validators.PrivateMessages
{
    public partial class SendPrivateMessageValidator : BaseNopValidator<SendPrivateMessageModel>
    {
        public SendPrivateMessageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.SubjectCannotBeEmpty"));
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.MessageCannotBeEmpty"));
        }
    }
}