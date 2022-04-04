using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Orders;
using BWire.Web.Models.Mobile.Checkout;
using BWire.Web.Models.Mobile.Customer;
using BWire.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWire.Web.Factories.Mobile
{
    public interface ICustomerMobFactory
    {
        IList<BillingAddressMobModel> PrepareCustomerAddressesModel(Customer customer);
        CustomerOrderListModel PrepareCustomerOrderListModel(Customer customer);
        OrderDetailsModel PrepareOrderDetailsModel(Order order);
    }
}
