using FluentValidation;
using BWire.Core.Domain.Common;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Common;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Common
{
    public partial class AddressAttributeValidator : BaseNopValidator<AddressAttributeModel>
    {
        public AddressAttributeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttribute>(dataProvider);
        }
    }
}