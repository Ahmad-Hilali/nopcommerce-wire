using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor search model
    /// </summary>
    public partial class VendorSearchModel : BaseSearchModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Vendors.List.SearchName")]
        public string SearchName { get; set; }

        [NopResourceDisplayName("Admin.Vendors.List.SearchEmail")]
        public string SearchEmail { get; set; }

        #endregion
    }
}