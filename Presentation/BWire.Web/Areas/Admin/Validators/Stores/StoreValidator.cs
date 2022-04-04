using FluentValidation;
using BWire.Core.Domain.Stores;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Stores;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Stores
{
    public partial class StoreValidator : BaseNopValidator<StoreModel>
    {
        public StoreValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Name.Required"));
            RuleFor(x => x.Url).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Stores.Fields.Url.Required"));

            SetDatabaseValidationRules<Store>(dataProvider);
        }
    }
}