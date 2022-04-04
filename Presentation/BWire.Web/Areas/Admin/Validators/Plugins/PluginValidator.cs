using FluentValidation;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Plugins;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Plugins
{
    public partial class PluginValidator : BaseNopValidator<PluginModel>
    {
        public PluginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendlyName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
        }
    }
}