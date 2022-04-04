using System.Collections.Generic;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a associated external auth records search model
    /// </summary>
    public class CustomerAssociatedExternalAuthRecordsSearchModel : BaseSearchModel
    {
        #region Properties

        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth")]
        public IList<CustomerAssociatedExternalAuthModel> AssociatedExternalAuthRecords { get; set; } = new List<CustomerAssociatedExternalAuthModel>();
        
        #endregion
    }
}
