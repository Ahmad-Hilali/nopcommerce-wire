using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System.Collections.Generic;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class ProductReviewOverviewMobModel : BaseNopModel
    {
        public int ProductId { get; set; }

        public int RatingSum { get; set; }

        public int TotalReviews { get; set; }

        public bool AllowCustomerReviews { get; set; }
    }

    public partial class ProductReviewsMobModel : BaseNopModel
    {
        public ProductReviewsMobModel()
        {
            Items = new List<ProductReviewMobModel>();
            AddProductReview = new AddProductReviewMobModel();
            ReviewTypeList = new List<ReviewTypeMobModel>();
            AddAdditionalProductReviewList = new List<AddProductReviewReviewTypeMappingMobModel>();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSeName { get; set; }

        public IList<ProductReviewMobModel> Items { get; set; }

        public AddProductReviewMobModel AddProductReview { get; set; }

        public IList<ReviewTypeMobModel> ReviewTypeList { get; set; }

        public IList<AddProductReviewReviewTypeMappingMobModel> AddAdditionalProductReviewList { get; set; }
    }

    public partial class ReviewTypeMobModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsRequired { get; set; }

        public bool VisibleToAllCustomers { get; set; }

        public double AverageRating { get; set; }
    }

    public partial class ProductReviewMobModel : BaseNopEntityModel
    {
        public ProductReviewMobModel()
        {
            AdditionalProductReviewList = new List<ProductReviewReviewTypeMappingMobModel>();
        }

        public int CustomerId { get; set; }

        public string CustomerAvatarUrl { get; set; }

        public string CustomerName { get; set; }

        public bool AllowViewingProfiles { get; set; }

        public string Title { get; set; }

        public string ReviewText { get; set; }

        public string ReplyText { get; set; }

        public int Rating { get; set; }

        public string WrittenOnStr { get; set; }

        public ProductReviewHelpfulnessMobModel Helpfulness { get; set; }

        public IList<ProductReviewReviewTypeMappingMobModel> AdditionalProductReviewList { get; set; }
    }

    public partial class ProductReviewHelpfulnessMobModel : BaseNopModel
    {
        public int ProductReviewId { get; set; }

        public int HelpfulYesTotal { get; set; }

        public int HelpfulNoTotal { get; set; }
    }

    public partial class AddProductReviewMobModel : BaseNopModel
    {
        [NopResourceDisplayName("Reviews.Fields.Title")]
        public string Title { get; set; }

        [NopResourceDisplayName("Reviews.Fields.ReviewText")]
        public string ReviewText { get; set; }

        [NopResourceDisplayName("Reviews.Fields.Rating")]
        public int Rating { get; set; }

        public bool DisplayCaptcha { get; set; }

        public bool CanCurrentCustomerLeaveReview { get; set; }

        public bool SuccessfullyAdded { get; set; }

        public string Result { get; set; }
    }

    public partial class AddProductReviewReviewTypeMappingMobModel : BaseNopEntityModel
    {
        public int ProductReviewId { get; set; }

        public int ReviewTypeId { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsRequired { get; set; }
    }

    public partial class ProductReviewReviewTypeMappingMobModel : BaseNopEntityModel
    {
        public int ProductReviewId { get; set; }

        public int ReviewTypeId { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public bool VisibleToAllCustomers { get; set; }
    }
}