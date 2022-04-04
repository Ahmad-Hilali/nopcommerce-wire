using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents a order cache event consumer
    /// </summary>
    public partial class OrderCacheEventConsumer : CacheEventConsumer<Order>
    {
    }
}