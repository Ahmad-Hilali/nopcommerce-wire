using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliated customer model
    /// </summary>
    public partial class AffiliatedCustomerModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Affiliates.Customers.Name")]
        public string Name { get; set; }

        #endregion
    }
}