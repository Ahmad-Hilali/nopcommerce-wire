using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer back in stock subscriptions search model
    /// </summary>
    public partial class CustomerBackInStockSubscriptionSearchModel : BaseSearchModel
    {
        #region Properties

        public int CustomerId { get; set; }

        #endregion
    }
}