using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an incomplete order report model
    /// </summary>
    public partial class OrderIncompleteReportModel : BaseNopModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.SalesReport.Incomplete.Item")]
        public string Item { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Incomplete.Total")]
        public string Total { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Incomplete.Count")]
        public int Count { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Incomplete.View")]
        public string ViewLink { get; set; }

        #endregion
    }
}