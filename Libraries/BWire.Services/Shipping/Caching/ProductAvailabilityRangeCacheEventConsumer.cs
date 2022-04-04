using BWire.Core.Domain.Shipping;
using BWire.Services.Caching;

namespace BWire.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a product availability range cache event consumer
    /// </summary>
    public partial class ProductAvailabilityRangeCacheEventConsumer : CacheEventConsumer<ProductAvailabilityRange>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductAvailabilityRange entity)
        {
            Remove(NopShippingDefaults.ProductAvailabilityAllCacheKey);
        }
    }
}