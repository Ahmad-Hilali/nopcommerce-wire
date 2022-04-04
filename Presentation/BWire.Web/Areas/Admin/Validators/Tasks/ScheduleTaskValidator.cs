using FluentValidation;
using BWire.Core.Domain.Tasks;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Tasks;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Tasks
{
    public partial class ScheduleTaskValidator : BaseNopValidator<ScheduleTaskModel>
    {
        public ScheduleTaskValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.Name.Required"));
            RuleFor(x => x.Seconds).GreaterThan(0).WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.Seconds.Positive"));

            SetDatabaseValidationRules<ScheduleTask>(dataProvider);
        }
    }
}