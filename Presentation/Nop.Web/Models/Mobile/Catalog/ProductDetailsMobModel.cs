using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Models.Mobile.Media;
using Nop.Web.Models.Mobile.ShoppingCart;
using Nop.Web.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class ProductDetailsMobModel : BaseNopEntityModel
    {
        public ProductDetailsMobModel()
        {
            DefaultPictureModel = new PictureMobModel();
            PictureModels = new List<PictureMobModel>();
            GiftCard = new GiftCardMobModel();
            ProductPrice = new ProductPriceMobModel();
            AddToCart = new AddToCartMobModel();
            ProductAttributes = new List<ProductAttributeMobModel>();
            AssociatedProducts = new List<ProductDetailsMobModel>();
            VendorModel = new VendorBriefInfoMobModel();
            Breadcrumb = new ProductBreadcrumbMobModel();
            ProductTags = new List<ProductTagMobModel>();
            ProductSpecifications = new List<ProductSpecificationMobModel>();
            ProductManufacturers = new List<ManufacturerBriefInfoMobModel>();
            ProductReviewOverview = new ProductReviewOverviewMobModel();
            TierPrices = new List<TierPriceMobModel>();
            ProductEstimateShipping = new ProductEstimateShippingMobModel();
        }

        //picture(s)
        public bool DefaultPictureZoomEnabled { get; set; }
        public PictureMobModel DefaultPictureModel { get; set; }
        public IList<PictureMobModel> PictureModels { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }

        public ProductType ProductType { get; set; }

        public bool ShowSku { get; set; }
        public string Sku { get; set; }

        public bool ShowManufacturerPartNumber { get; set; }
        public string ManufacturerPartNumber { get; set; }

        public bool ShowGtin { get; set; }
        public string Gtin { get; set; }

        public bool ShowVendor { get; set; }
        public VendorBriefInfoMobModel VendorModel { get; set; }

        public bool HasSampleDownload { get; set; }

        public GiftCardMobModel GiftCard { get; set; }

        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool FreeShippingNotificationEnabled { get; set; }
        public string DeliveryDate { get; set; }

        public bool IsRental { get; set; }
        public DateTime? RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }

        public DateTime? AvailableEndDate { get; set; }

        public ManageInventoryMethod ManageInventoryMethod { get; set; }

        public string StockAvailability { get; set; }

        public bool DisplayBackInStockSubscription { get; set; }

        public bool EmailAFriendEnabled { get; set; }
        public bool CompareProductsEnabled { get; set; }

        public string PageShareCode { get; set; }

        public ProductPriceMobModel ProductPrice { get; set; }

        public AddToCartMobModel AddToCart { get; set; }

        public ProductBreadcrumbMobModel Breadcrumb { get; set; }

        public IList<ProductTagMobModel> ProductTags { get; set; }

        public IList<ProductAttributeMobModel> ProductAttributes { get; set; }

        public IList<ProductSpecificationMobModel> ProductSpecifications { get; set; }

        public IList<ManufacturerBriefInfoMobModel> ProductManufacturers { get; set; }

        public ProductReviewOverviewMobModel ProductReviewOverview { get; set; }

        public ProductEstimateShippingMobModel ProductEstimateShipping { get; set; }

        public IList<TierPriceMobModel> TierPrices { get; set; }

        //a list of associated products. For example, "Grouped" products could have several child "simple" products
        public IList<ProductDetailsMobModel> AssociatedProducts { get; set; }

        public bool DisplayDiscontinuedMessage { get; set; }

        public string CurrentStoreName { get; set; }

        #region Nested Classes

        public partial class ProductBreadcrumbMobModel : BaseNopModel
        {
            public ProductBreadcrumbMobModel()
            {
                CategoryBreadcrumb = new List<CategorySimpleMobModel>();
            }

            public bool Enabled { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductSeName { get; set; }
            public IList<CategorySimpleMobModel> CategoryBreadcrumb { get; set; }
        }

        public partial class AddToCartMobModel : BaseNopModel
        {
            public AddToCartMobModel()
            {
                AllowedQuantities = new List<SelectListItem>();
            }
            public int ProductId { get; set; }

            //qty
            [NopResourceDisplayName("Products.Qty")]
            public int EnteredQuantity { get; set; }
            public string MinimumQuantityNotification { get; set; }
            public List<SelectListItem> AllowedQuantities { get; set; }

            //price entered by customers
            [NopResourceDisplayName("Products.EnterProductPrice")]
            public bool CustomerEntersPrice { get; set; }
            [NopResourceDisplayName("Products.EnterProductPrice")]
            public decimal CustomerEnteredPrice { get; set; }
            public string CustomerEnteredPriceRange { get; set; }

            public bool DisableBuyButton { get; set; }
            public bool DisableWishlistButton { get; set; }

            //rental
            public bool IsRental { get; set; }

            //pre-order
            public bool AvailableForPreOrder { get; set; }
            public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
            public string PreOrderAvailabilityStartDateTimeUserTime { get; set; }

            //updating existing shopping cart or wishlist item?
            public int UpdatedShoppingCartItemId { get; set; }
            public ShoppingCartType? UpdateShoppingCartItemType { get; set; }
        }

        public partial class ProductPriceMobModel : BaseNopModel
        {
            /// <summary>
            /// The currency (in 3-letter ISO 4217 format) of the offer price 
            /// </summary>
            public string CurrencyCode { get; set; }

            public string OldPrice { get; set; }

            public string Price { get; set; }
            public string PriceWithDiscount { get; set; }
            public decimal PriceValue { get; set; }

            public bool CustomerEntersPrice { get; set; }

            public bool CallForPrice { get; set; }

            public int ProductId { get; set; }

            public bool HidePrices { get; set; }

            //rental
            public bool IsRental { get; set; }
            public string RentalPrice { get; set; }

            /// <summary>
            /// A value indicating whether we should display tax/shipping info (used in Germany)
            /// </summary>
            public bool DisplayTaxShippingInfo { get; set; }
            /// <summary>
            /// PAngV baseprice (used in Germany)
            /// </summary>
            public string BasePricePAngV { get; set; }
        }

        public partial class GiftCardMobModel : BaseNopModel
        {
            public bool IsGiftCard { get; set; }

            [NopResourceDisplayName("Products.GiftCard.RecipientName")]
            public string RecipientName { get; set; }

            [NopResourceDisplayName("Products.GiftCard.RecipientEmail")]
            [DataType(DataType.EmailAddress)]
            public string RecipientEmail { get; set; }

            [NopResourceDisplayName("Products.GiftCard.SenderName")]
            public string SenderName { get; set; }

            [NopResourceDisplayName("Products.GiftCard.SenderEmail")]
            [DataType(DataType.EmailAddress)]
            public string SenderEmail { get; set; }

            [NopResourceDisplayName("Products.GiftCard.Message")]
            public string Message { get; set; }

            public GiftCardType GiftCardType { get; set; }
        }

        public partial class TierPriceMobModel : BaseNopModel
        {
            public string Price { get; set; }

            public int Quantity { get; set; }
        }

        public partial class ProductAttributeMobModel : BaseNopEntityModel
        {
            public ProductAttributeMobModel()
            {
                AllowedFileExtensions = new List<string>();
                Values = new List<ProductAttributeValueMobModel>();
            }

            public int ProductId { get; set; }

            public int ProductAttributeId { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string TextPrompt { get; set; }

            public bool IsRequired { get; set; }

            /// <summary>
            /// Default value for textboxes
            /// </summary>
            public string DefaultValue { get; set; }
            /// <summary>
            /// Selected day value for datepicker
            /// </summary>
            public int? SelectedDay { get; set; }
            /// <summary>
            /// Selected month value for datepicker
            /// </summary>
            public int? SelectedMonth { get; set; }
            /// <summary>
            /// Selected year value for datepicker
            /// </summary>
            public int? SelectedYear { get; set; }

            /// <summary>
            /// A value indicating whether this attribute depends on some other attribute
            /// </summary>
            public bool HasCondition { get; set; }

            /// <summary>
            /// Allowed file extensions for customer uploaded files
            /// </summary>
            public IList<string> AllowedFileExtensions { get; set; }

            public AttributeControlType AttributeControlType { get; set; }

            public IList<ProductAttributeValueMobModel> Values { get; set; }
        }

        public partial class ProductAttributeValueMobModel : BaseNopEntityModel
        {
            public ProductAttributeValueMobModel()
            {
                ImageSquaresPictureModel = new PictureMobModel();
            }

            public string Name { get; set; }

            public string ColorSquaresRgb { get; set; }

            //picture model is used with "image square" attribute type
            public PictureMobModel ImageSquaresPictureModel { get; set; }

            public string PriceAdjustment { get; set; }

            public bool PriceAdjustmentUsePercentage { get; set; }

            public decimal PriceAdjustmentValue { get; set; }

            public bool IsPreSelected { get; set; }

            //product picture ID (associated to this value)
            public int PictureId { get; set; }

            public bool CustomerEntersQty { get; set; }

            public int Quantity { get; set; }
        }

        public partial class ProductEstimateShippingMobModel : EstimateShippingMobModel
        {
            public int ProductId { get; set; }
        }

        #endregion
    }
}
