using System;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount usage history model
    /// </summary>
    public partial class DiscountUsageHistoryModel : BaseNopEntityModel
    {
        #region Properties

        public int DiscountId { get; set; }

        public int OrderId { get; set; }

        [NopResourceDisplayName("Admin.Promotions.Discounts.History.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [NopResourceDisplayName("Admin.Promotions.Discounts.History.OrderTotal")]
        public string OrderTotal { get; set; }

        [NopResourceDisplayName("Admin.Promotions.Discounts.History.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}