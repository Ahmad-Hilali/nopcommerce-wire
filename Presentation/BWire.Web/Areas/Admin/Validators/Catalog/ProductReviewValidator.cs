using FluentValidation;
using BWire.Core;
using BWire.Core.Domain.Catalog;
using BWire.Data;
using BWire.Services.Localization;
using BWire.Web.Areas.Admin.Models.Catalog;
using BWire.Web.Framework.Validators;

namespace BWire.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductReviewValidator : BaseNopValidator<ProductReviewModel>
    {
        public ProductReviewValidator(ILocalizationService localizationService, INopDataProvider dataProvider, IWorkContext workContext)
        {
            var isLoggedInAsVendor = workContext.CurrentVendor != null;
            //vendor can edit "Reply text" only
            if (!isLoggedInAsVendor)
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.Title.Required"));
                RuleFor(x => x.ReviewText).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
            }

            SetDatabaseValidationRules<ProductReview>(dataProvider);
        }
    }
}