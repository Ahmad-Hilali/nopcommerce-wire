using Microsoft.AspNetCore.Mvc;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class SelectedCheckoutAttributesViewComponent : NopViewComponent
    {
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;

        public SelectedCheckoutAttributesViewComponent(IShoppingCartModelFactory shoppingCartModelFactory)
        {
            _shoppingCartModelFactory = shoppingCartModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var attributes = _shoppingCartModelFactory.FormatSelectedCheckoutAttributes();
            return View(null, attributes);
        }
    }
}
