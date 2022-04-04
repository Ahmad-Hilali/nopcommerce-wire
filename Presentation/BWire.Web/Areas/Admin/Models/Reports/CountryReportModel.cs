using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a country report model
    /// </summary>
    public partial class CountryReportModel : BaseNopModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Reports.Sales.Country.Fields.CountryName")]
        public string CountryName { get; set; }

        [NopResourceDisplayName("Admin.Reports.Sales.Country.Fields.TotalOrders")]
        public int TotalOrders { get; set; }

        [NopResourceDisplayName("Admin.Reports.Sales.Country.Fields.SumOrders")]
        public string SumOrders { get; set; }

        #endregion
    }
}