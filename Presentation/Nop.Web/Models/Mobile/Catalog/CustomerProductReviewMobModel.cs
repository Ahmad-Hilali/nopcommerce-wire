using Nop.Web.Framework.Models;
using Nop.Web.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class CustomerProductReviewMobModel : BaseNopModel
    {
        public CustomerProductReviewMobModel()
        {
            AdditionalProductReviewList = new List<ProductReviewReviewTypeMappingMobModel>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSeName { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public string ReplyText { get; set; }
        public int Rating { get; set; }
        public string WrittenOnStr { get; set; }
        public string ApprovalStatus { get; set; }
        public IList<ProductReviewReviewTypeMappingMobModel> AdditionalProductReviewList { get; set; }
    }

    public class CustomerProductReviewsMobModel : BaseNopModel
    {
        public CustomerProductReviewsMobModel()
        {
            ProductReviews = new List<CustomerProductReviewMobModel>();
        }

        public IList<CustomerProductReviewMobModel> ProductReviews { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested class

        /// <summary>
        /// Class that has only page for route value. Used for (My Account) My Product Reviews pagination
        /// </summary>
        public partial class CustomerProductReviewsRouteValues : IRouteValues
        {
            public int pageNumber { get; set; }
        }

        #endregion
    }
}
