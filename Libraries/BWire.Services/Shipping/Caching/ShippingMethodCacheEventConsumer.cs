using BWire.Core.Domain.Shipping;
using BWire.Services.Caching;

namespace BWire.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a shipping method cache event consumer
    /// </summary>
    public partial class ShippingMethodCacheEventConsumer : CacheEventConsumer<ShippingMethod>
    {
        protected override void ClearCache(ShippingMethod entity)
        {
            RemoveByPrefix(NopShippingDefaults.ShippingMethodsAllPrefixCacheKey);
        }
    }
}
