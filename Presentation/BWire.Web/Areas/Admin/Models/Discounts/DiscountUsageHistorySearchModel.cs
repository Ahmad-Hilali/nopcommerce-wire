using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount usage history search model
    /// </summary>
    public partial class DiscountUsageHistorySearchModel : BaseSearchModel
    {
        #region Properties

        public int DiscountId { get; set; }

        #endregion
    }
}