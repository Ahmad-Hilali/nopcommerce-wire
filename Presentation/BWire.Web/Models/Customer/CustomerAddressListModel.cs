using System.Collections.Generic;
using BWire.Web.Framework.Models;
using BWire.Web.Models.Common;

namespace BWire.Web.Models.Customer
{
    public partial class CustomerAddressListModel : BaseNopModel
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
    }
}