using Nop.Web.Models.Mobile.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories.Mobile
{
    public interface ICheckoutMobFactory
    {
        IList<BillingAddressMobModel> GetValidAddressesByCustomerId(int customerId);
        IList<BillingAddressMobModel> GetInvalidAddressesByCustomerId(int customerId);
        BillingAddressMobModel PrepareAddressMobModel(int customerId);
    }
}
