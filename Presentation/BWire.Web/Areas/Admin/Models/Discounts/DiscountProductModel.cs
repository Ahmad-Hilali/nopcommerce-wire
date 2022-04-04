using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount product model
    /// </summary>
    public partial class DiscountProductModel : BaseNopEntityModel
    {
        #region Properties

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        #endregion
    }
}