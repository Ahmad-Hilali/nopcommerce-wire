using FluentValidation;
using BWire.Core.Domain.Forums;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Forums;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Forums
{
    public partial class ForumGroupValidator : BaseNopValidator<ForumGroupModel>
    {
        public ForumGroupValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));

            SetDatabaseValidationRules<ForumGroup>(dataProvider);
        }
    }
}