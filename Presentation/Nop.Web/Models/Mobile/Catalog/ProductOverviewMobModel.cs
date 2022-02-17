using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Mobile.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class ProductOverviewMobModel : BaseNopEntityModel
    {
        public ProductOverviewMobModel()
        {
            ProductPrice = new ProductPriceModel();
            DefaultPictureModel = new PictureMobModel();
            SpecificationAttributeModels = new List<ProductSpecificationMobModel>();
            ReviewOverviewModel = new ProductReviewOverviewMobModel();
        }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string SeName { get; set; }

        public string Sku { get; set; }

        public ProductType ProductType { get; set; }

        public bool MarkAsNew { get; set; }

        //price
        public ProductPriceModel ProductPrice { get; set; }
        //picture
        public PictureMobModel DefaultPictureModel { get; set; }
        //specification attributes
        public IList<ProductSpecificationMobModel> SpecificationAttributeModels { get; set; }
        //price
        public ProductReviewOverviewMobModel ReviewOverviewModel { get; set; }

        #region Nested Classes

        public partial class ProductPriceModel : BaseNopModel
        {
            public string OldPrice { get; set; }
            public string Price { get; set; }
            public decimal PriceValue { get; set; }
            /// <summary>
            /// PAngV baseprice (used in Germany)
            /// </summary>
            public string BasePricePAngV { get; set; }

            public bool DisableBuyButton { get; set; }
            public bool DisableWishlistButton { get; set; }
            public bool DisableAddToCompareListButton { get; set; }

            public bool AvailableForPreOrder { get; set; }
            public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }

            public bool IsRental { get; set; }

            public bool ForceRedirectionAfterAddingToCart { get; set; }

            /// <summary>
            /// A value indicating whether we should display tax/shipping info (used in Germany)
            /// </summary>
            public bool DisplayTaxShippingInfo { get; set; }
        }

        #endregion
    }
}
