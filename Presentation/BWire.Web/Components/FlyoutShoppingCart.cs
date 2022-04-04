using Microsoft.AspNetCore.Mvc;
using BWire.Core.Domain.Orders;
using BWire.Services.Security;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class FlyoutShoppingCartViewComponent : NopViewComponent
    {
        private readonly IPermissionService _permissionService;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly ShoppingCartSettings _shoppingCartSettings;

        public FlyoutShoppingCartViewComponent(IPermissionService permissionService,
            IShoppingCartModelFactory shoppingCartModelFactory,
            ShoppingCartSettings shoppingCartSettings)
        {
            _permissionService = permissionService;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartSettings = shoppingCartSettings;
        }

        public IViewComponentResult Invoke()
        {
            if (!_shoppingCartSettings.MiniShoppingCartEnabled)
                return Content("");

            if (!_permissionService.Authorize(StandardPermissionProvider.EnableShoppingCart))
                return Content("");

            var model = _shoppingCartModelFactory.PrepareMiniShoppingCartModel();
            return View(model);
        }
    }
}
