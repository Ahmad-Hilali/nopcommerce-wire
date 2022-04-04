using FluentValidation;
using BWire.Core.Domain.Topics;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Templates;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Templates
{
    public partial class TopicTemplateValidator : BaseNopValidator<TopicTemplateModel>
    {
        public TopicTemplateValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.Name.Required"));
            RuleFor(x => x.ViewPath).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.Templates.Topic.ViewPath.Required"));

            SetDatabaseValidationRules<TopicTemplate>(dataProvider);
        }
    }
}