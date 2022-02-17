using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Checkout
{
    public class BillingInputMobModel
    {
        public BillingAddressMobModel BillingAddress { get; set; }
        public int BillingAddressId { get; set; }
    }
}
