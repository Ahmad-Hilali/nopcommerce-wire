using Microsoft.AspNetCore.Mvc;
using BWire.Core;
using BWire.Core.Domain.Orders;
using BWire.Core.Domain.Shipping;
using BWire.Services.Orders;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    /// <summary>
    /// Represents a estimate shipping view component on shopping cart page
    /// </summary>
    public class ShoppingCartEstimateShippingViewComponent : NopViewComponent
    {
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly ShippingSettings _shippingSettings;

        public ShoppingCartEstimateShippingViewComponent(IShoppingCartModelFactory shoppingCartModelFactory,
            IShoppingCartService shoppingCartService,
            IStoreContext storeContext,
            IWorkContext workContext,
            ShippingSettings shippingSettings)
        {
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            _storeContext = storeContext;
            _workContext = workContext;
            _shippingSettings = shippingSettings;
        }

        public IViewComponentResult Invoke(bool? prepareAndDisplayOrderReviewData)
        {
            if (!_shippingSettings.EstimateShippingCartPageEnabled)
                return Content("");

            var cart = _shoppingCartService.GetShoppingCart(_workContext.CurrentCustomer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            var model = _shoppingCartModelFactory.PrepareEstimateShippingModel(cart);
            if (!model.Enabled)
                return Content("");

            return View(model);
        }
    }
}
