using FluentValidation;
using BWire.Core.Domain.Polls;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Polls;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Polls
{
    public partial class PollAnswerValidator : BaseNopValidator<PollAnswerModel>
    {
        public PollAnswerValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            //if validation without this set rule is applied, in this case nothing will be validated
            //it's used to prevent auto-validation of child models
            RuleSet(NopValidatorDefaults.ValidationRuleSet, () =>
            {
                RuleFor(model => model.Name)
                    .NotEmpty()
                    .WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Answers.Fields.Name.Required"));

                SetDatabaseValidationRules<PollAnswer>(dataProvider);
            });
        }
    }
}