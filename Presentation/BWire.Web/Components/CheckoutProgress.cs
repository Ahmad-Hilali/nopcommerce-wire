using Microsoft.AspNetCore.Mvc;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;
using BWire.Web.Models.Checkout;

namespace BWire.Web.Components
{
    public class CheckoutProgressViewComponent : NopViewComponent
    {
        private readonly ICheckoutModelFactory _checkoutModelFactory;

        public CheckoutProgressViewComponent(ICheckoutModelFactory checkoutModelFactory)
        {
            _checkoutModelFactory = checkoutModelFactory;
        }

        public IViewComponentResult Invoke(CheckoutProgressStep step)
        {
            var model = _checkoutModelFactory.PrepareCheckoutProgressModel(step);
            return View(model);
        }
    }
}
