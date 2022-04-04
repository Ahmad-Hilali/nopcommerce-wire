using FluentValidation;
using BWire.Core.Domain.Messages;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Messages;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Messages
{
    public partial class EmailAccountValidator : BaseNopValidator<EmailAccountModel>
    {
        public EmailAccountValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));

            RuleFor(x => x.DisplayName).NotEmpty();

            SetDatabaseValidationRules<EmailAccount>(dataProvider);
        }
    }
}