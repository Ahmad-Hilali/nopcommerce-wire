using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents an order item cache event consumer
    /// </summary>
    public partial class OrderItemCacheEventConsumer : CacheEventConsumer<OrderItem>
    {
    }
}
