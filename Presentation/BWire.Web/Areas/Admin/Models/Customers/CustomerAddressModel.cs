using BWire.Web.Areas.Admin.Models.Common;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer address model
    /// </summary>
    public partial class CustomerAddressModel : BaseNopModel
    {
        #region Ctor

        public CustomerAddressModel()
        {
            Address = new AddressModel();
        }

        #endregion

        #region Properties

        public int CustomerId { get; set; }

        public AddressModel Address { get; set; }

        #endregion
    }
}