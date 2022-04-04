using FluentValidation;
using BWire.Core.Domain.Polls;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Polls;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Polls
{
    public partial class PollValidator : BaseNopValidator<PollModel>
    {
        public PollValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Fields.Name.Required"));

            SetDatabaseValidationRules<Poll>(dataProvider);
        }
    }
}