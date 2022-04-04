using BWire.Core.Domain.Shipping;
using BWire.Services.Caching;

namespace BWire.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a delivery date cache event consumer
    /// </summary>
    public partial class DeliveryDateCacheEventConsumer : CacheEventConsumer<DeliveryDate>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(DeliveryDate entity)
        {
            Remove(NopShippingDefaults.DeliveryDatesAllCacheKey);
        }
    }
}