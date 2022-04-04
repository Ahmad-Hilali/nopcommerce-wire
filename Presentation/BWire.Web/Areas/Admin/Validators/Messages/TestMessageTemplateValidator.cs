using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Messages;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Messages
{
    public partial class TestMessageTemplateValidator : BaseNopValidator<TestMessageTemplateModel>
    {
        public TestMessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SendTo).NotEmpty();
            RuleFor(x => x.SendTo).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}