using FluentValidation;
using BWire.Core.Domain.Forums;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Forums;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Forums
{
    public partial class ForumValidator : BaseNopValidator<ForumModel>
    {
        public ForumValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.Name.Required"));
            RuleFor(x => x.ForumGroupId).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId.Required"));

            SetDatabaseValidationRules<Forum>(dataProvider);
        }
    }
}