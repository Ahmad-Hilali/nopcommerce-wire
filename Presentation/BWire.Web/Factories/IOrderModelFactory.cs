using BWire.Core.Domain.Orders;
using BWire.Core.Domain.Shipping;
using BWire.Web.Models.Order;

namespace BWire.Web.Factories
{
    /// <summary>
    /// Represents the interface of the order model factory
    /// </summary>
    public partial interface IOrderModelFactory
    {
        /// <summary>
        /// Prepare the customer order list model
        /// </summary>
        /// <returns>Customer order list model</returns>
        CustomerOrderListModel PrepareCustomerOrderListModel();

        /// <summary>
        /// Prepare the order details model
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Order details model</returns>
        OrderDetailsModel PrepareOrderDetailsModel(Order order);

        /// <summary>
        /// Prepare the shipment details model
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <returns>Shipment details model</returns>
        ShipmentDetailsModel PrepareShipmentDetailsModel(Shipment shipment);

        /// <summary>
        /// Prepare the customer reward points model
        /// </summary>
        /// <param name="page">Number of items page; pass null to load the first page</param>
        /// <returns>Customer reward points model</returns>
        CustomerRewardPointsModel PrepareCustomerRewardPoints(int? page);
    }
}
