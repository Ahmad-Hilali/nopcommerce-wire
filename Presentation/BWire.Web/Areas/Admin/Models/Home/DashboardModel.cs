using BWire.Web.Areas.Admin.Models.Common;
using BWire.Web.Areas.Admin.Models.Reports;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a dashboard model
    /// </summary>
    public partial class DashboardModel : BaseNopModel
    {
        #region Ctor

        public DashboardModel()
        {
            PopularSearchTerms = new PopularSearchTermSearchModel();
            BestsellersByAmount = new BestsellerBriefSearchModel();
            BestsellersByQuantity = new BestsellerBriefSearchModel();
        }

        #endregion

        #region Properties

        public bool IsLoggedInAsVendor { get; set; }

        public PopularSearchTermSearchModel PopularSearchTerms { get; set; }

        public BestsellerBriefSearchModel BestsellersByAmount { get; set; }

        public BestsellerBriefSearchModel BestsellersByQuantity { get; set; }

        #endregion
    }
}