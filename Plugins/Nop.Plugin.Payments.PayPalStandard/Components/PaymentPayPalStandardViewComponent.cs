using Microsoft.AspNetCore.Mvc;
using BWire.Web.Framework.Components;

namespace Nop.Plugin.Payments.PayPalStandard.Components
{
    [ViewComponent(Name = "PaymentPayPalStandard")]
    public class PaymentPayPalStandardViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Payments.PayPalStandard/Views/PaymentInfo.cshtml");
        }
    }
}
