using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Web.Models.Mobile.Checkout;
using Nop.Web.Models.Mobile.Customer;
using Nop.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories.Mobile
{
    public interface ICustomerMobFactory
    {
        IList<BillingAddressMobModel> PrepareCustomerAddressesModel(Customer customer);
        CustomerOrderListModel PrepareCustomerOrderListModel(Customer customer);
        OrderDetailsModel PrepareOrderDetailsModel(Order order);
    }
}
