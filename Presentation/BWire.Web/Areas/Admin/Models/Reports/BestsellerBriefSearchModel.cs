using BWire.Services.Orders;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a bestseller brief search model
    /// </summary>
    public partial class BestsellerBriefSearchModel : BaseSearchModel
    {
        #region Properties

        public OrderByEnum OrderBy { get; set; }

        #endregion
    }
}