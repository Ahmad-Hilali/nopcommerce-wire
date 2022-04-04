using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Framework.Validators;
using BWire.Web.Models.Boards;

namespace BWire.Web.Validators.Boards
{
    public partial class EditForumTopicValidator : BaseNopValidator<EditForumTopicModel>
    {
        public EditForumTopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("Forum.TopicSubjectCannotBeEmpty"));
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}