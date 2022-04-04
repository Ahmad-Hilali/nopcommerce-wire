using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents a return request cache event consumer
    /// </summary>
    public partial class ReturnRequestCacheEventConsumer : CacheEventConsumer<ReturnRequest>
    {
    }
}
