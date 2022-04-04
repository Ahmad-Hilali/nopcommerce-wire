using FluentValidation;
using BWire.Core.Domain.Messages;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Messages;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Messages
{
    public partial class MessageTemplateValidator : BaseNopValidator<MessageTemplateModel>
    {
        public MessageTemplateValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Subject.Required"));
            RuleFor(x => x.Body).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Body.Required"));

            SetDatabaseValidationRules<MessageTemplate>(dataProvider);
        }
    }
}