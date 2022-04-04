using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;
using BWire.Services.Discounts;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a manufacturer cache event consumer
    /// </summary>
    public partial class ManufacturerCacheEventConsumer : CacheEventConsumer<Manufacturer>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Manufacturer entity)
        {
            RemoveByPrefix(NopDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }
    }
}
