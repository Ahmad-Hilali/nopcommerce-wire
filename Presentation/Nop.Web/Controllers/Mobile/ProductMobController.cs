using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Orders;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Models.Catalog;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMobController : ControllerBase
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICompareProductsService _compareProductsService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IOrderService _orderService;
        private readonly IPermissionService _permissionService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly IReviewTypeService _reviewTypeService;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly ShoppingCartSettings _shoppingCartSettings;

        #endregion

        #region Ctor

        public ProductMobController(
            CatalogSettings catalogSettings,
            IAclService aclService,
            ICompareProductsService compareProductsService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IProductAttributeParser productAttributeParser,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IOrderService orderService,
            IRecentlyViewedProductsService recentlyViewedProductsService,
            IReviewTypeService reviewTypeService,
            IShoppingCartModelFactory shoppingCartModelFactory,
            IShoppingCartService shoppingCartService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IWebHelper webHelper,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings,
            ShoppingCartSettings shoppingCartSettings)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _compareProductsService = compareProductsService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _orderService = orderService;
            _permissionService = permissionService;
            _productAttributeParser = productAttributeParser;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _reviewTypeService = reviewTypeService;
            _recentlyViewedProductsService = recentlyViewedProductsService;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _webHelper = webHelper;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
            _shoppingCartSettings = shoppingCartSettings;
        }
        #endregion
        #region Product details
        [HttpGet]
        [Route("ProductDetails")]
        public IActionResult ProductDetails(int productId, int updatecartitemid = 0)
        {
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted)
                return NotFound();

            var notAvailable =
                //published?
                (!product.Published && !_catalogSettings.AllowViewUnpublishedProductPage) ||
                //ACL (access control list) 
                !_aclService.Authorize(product) ||
                //Store mapping
                !_storeMappingService.Authorize(product) ||
                //availability dates
                !_productService.ProductIsAvailable(product);
            //Check whether the current user has a "Manage products" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            //var hasAdminAccess = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageProducts);
            if (notAvailable)
                return NotFound();

            //visible individually?
            //if (!product.VisibleIndividually)
            //{
            //    //is this one an associated products?
            //    var parentGroupedProduct = _productService.GetProductById(product.ParentGroupedProductId);
            //    if (parentGroupedProduct == null)
            //        return RedirectToRoute("Homepage");

            //    return RedirectToRoutePermanent("Product", new { SeName = _urlRecordService.GetSeName(parentGroupedProduct) });
            //}

            //update existing shopping cart or wishlist  item?
            ShoppingCartItem updatecartitem = null;
            //if (_shoppingCartSettings.AllowCartItemEditing && updatecartitemid > 0)
            //{
            //    var cart = _shoppingCartService.GetShoppingCart(_workContext.CurrentCustomer, storeId: _storeContext.CurrentStore.Id);
            //    updatecartitem = cart.FirstOrDefault(x => x.Id == updatecartitemid);
            //    //not found?
            //    if (updatecartitem == null)
            //    {
            //        return RedirectToRoute("Product", new { SeName = _urlRecordService.GetSeName(product) });
            //    }
            //    //is it this product?
            //    if (product.Id != updatecartitem.ProductId)
            //    {
            //        return RedirectToRoute("Product", new { SeName = _urlRecordService.GetSeName(product) });
            //    }
            //}

            //save as recently viewed
            _recentlyViewedProductsService.AddProductToRecentlyViewedList(product.Id);

            
            //activity log
            _customerActivityService.InsertActivity("PublicStore.ViewProduct",
                string.Format(_localizationService.GetResource("ActivityLog.PublicStore.ViewProduct"), product.Name), product);

            //model
            var model = _productModelFactory.PrepareProductDetailsModel(product, updatecartitem, false);
            var returnModel = new
            {
                Id = model.Id,
                CurrentStoreName = model.CurrentStoreName,
                DefaultPictureModel = model.DefaultPictureModel,
                PictureModels = model.PictureModels,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                FullDescription = model.FullDescription,
                MetaDescription = model.MetaDescription,
                SeName = model.SeName,
                ProductType = model.ProductType,
                Sku = model.Sku,
                IsShipEnabled = model.IsShipEnabled,
                IsFreeShipping = model.IsFreeShipping,
                CompareProductsEnabled = model.CompareProductsEnabled,
                ProductPrice = model.ProductPrice,
                AddToCart = model.AddToCart,
                Breadcrumb = model.Breadcrumb,
                ProductTags = model.ProductTags,
                ProductReviewOverview = model.ProductReviewOverview
            };
            return Ok(returnModel);
        }
        #endregion

        #region Product reviews

        [Route("ProductReviews")]
        public IActionResult ProductReviews(int productId)
        {
            Request.Headers.TryGetValue("token", out var token);
            var customer = _workContext.CurrentCustomer;
            if (!string.IsNullOrEmpty(token))
            {
                Guid guid = Guid.Parse(token);
                customer = _customerService.GetCustomerByGuid(guid);
            }
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !product.AllowCustomerReviews)
                return NotFound();

            var model = new ProductReviewsModel();
            model = _productModelFactory.PrepareProductReviewsModel(model, product);
            if (_catalogSettings.ProductReviewPossibleOnlyAfterPurchasing)
            {
                var hasCompletedOrders = _orderService.SearchOrders(customerId: customer.Id,
                    productId: productId,
                    osIds: new List<int> { (int)OrderStatus.Complete },
                    pageSize: 1).Any();
                if (!hasCompletedOrders)
                    return Ok(new { Msg = _localizationService.GetResource("Reviews.ProductReviewPossibleOnlyAfterPurchasing"), IsEnabled = false });
            }

            return Ok(new { Reviews = model.Items, DefaultReview = _catalogSettings.DefaultProductRatingValue });
        }
        [HttpPost]
        [Route("ProductReviewsAdd")]
        public virtual IActionResult ProductReviewsAdd(int productId, AddProductReviewModel model)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new { Msg = "Token Not Found", Success = false });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new { Msg = _localizationService.GetResource("Reviews.OnlyRegisteredUsersCanWriteReviews"), Success = false });
            var product = _productService.GetProductById(productId);
            if (product == null || product.Deleted || !product.Published || !product.AllowCustomerReviews)
                 return Ok(new { Msg = "Product Not Found", Success = false });

            if (_catalogSettings.ProductReviewPossibleOnlyAfterPurchasing)
            {
                var hasCompletedOrders = _orderService.SearchOrders(customerId: customer.Id,
                    productId: productId,
                    osIds: new List<int> { (int)OrderStatus.Complete },
                    pageSize: 1).Any();
                if (!hasCompletedOrders)
                    return Ok(new { Msg = _localizationService.GetResource("Reviews.ProductReviewPossibleOnlyAfterPurchasing"), IsEnabled = false });
            }

            if (ModelState.IsValid)
            {
                //save review
                var rating = model.Rating;
                if (rating < 1 || rating > 5)
                    rating = _catalogSettings.DefaultProductRatingValue;
                var isApproved = !_catalogSettings.ProductReviewsMustBeApproved;

                var productReview = new ProductReview
                {
                    ProductId = product.Id,
                    CustomerId = customer.Id,
                    Title = model.Title,
                    ReviewText = model.ReviewText,
                    Rating = rating,
                    HelpfulYesTotal = 0,
                    HelpfulNoTotal = 0,
                    IsApproved = isApproved,
                    CreatedOnUtc = DateTime.UtcNow,
                    StoreId = _storeContext.CurrentStore.Id,
                };

                _productService.InsertProductReview(productReview);

                //add product review and review type mapping                
                //foreach (var additionalReview in model.AddAdditionalProductReviewList)
                //{
                //    var additionalProductReview = new ProductReviewReviewTypeMapping
                //    {
                //        ProductReviewId = productReview.Id,
                //        ReviewTypeId = additionalReview.ReviewTypeId,
                //        Rating = additionalReview.Rating
                //    };

                //    _reviewTypeService.InsertProductReviewReviewTypeMappings(additionalProductReview);
                //}

                //update product totals
                _productService.UpdateProductReviewTotals(product);

                //notify store owner
                if (_catalogSettings.NotifyStoreOwnerAboutNewProductReviews)
                    _workflowMessageService.SendProductReviewNotificationMessage(productReview, _localizationSettings.DefaultAdminLanguageId);

                //activity log
                _customerActivityService.InsertActivity("PublicStore.AddProductReview",
                    string.Format(_localizationService.GetResource("ActivityLog.PublicStore.AddProductReview"), product.Name), product);

                //raise event
                if (productReview.IsApproved)
                    _eventPublisher.Publish(new ProductReviewApprovedEvent(productReview));

                if (!isApproved)
                    return Ok(new { Msg = _localizationService.GetResource("Reviews.SeeAfterApproving"), IsApproved = false });
                else
                    return Ok(new { Msg = _localizationService.GetResource("Reviews.SuccessfullyAdded"), IsApproved = false });
            }
            return Ok(model);
        }
        #endregion
    }
}
