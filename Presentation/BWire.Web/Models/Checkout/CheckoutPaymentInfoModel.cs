using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Checkout
{
    public partial class CheckoutPaymentInfoModel : BaseNopModel
    {
        public string PaymentViewComponentName { get; set; }

        /// <summary>
        /// Used on one-page checkout page
        /// </summary>
        public bool DisplayOrderTotals { get; set; }
    }
}