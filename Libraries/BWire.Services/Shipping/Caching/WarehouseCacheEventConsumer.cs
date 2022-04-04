using BWire.Core.Domain.Shipping;
using BWire.Services.Caching;

namespace BWire.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a warehouse cache event consumer
    /// </summary>
    public partial class WarehouseCacheEventConsumer : CacheEventConsumer<Warehouse>
    {
        protected override void ClearCache(Warehouse entity)
        {
            Remove(NopShippingDefaults.WarehousesAllCacheKey);
        }
    }
}
