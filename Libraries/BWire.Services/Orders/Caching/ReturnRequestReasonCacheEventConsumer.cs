using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents a return request reason cache event consumer
    /// </summary>
    public partial class ReturnRequestReasonCacheEventConsumer : CacheEventConsumer<ReturnRequestReason>
    {
        protected override void ClearCache(ReturnRequestReason entity)
        {
            Remove(NopOrderDefaults.ReturnRequestReasonAllCacheKey);
        }
    }
}
