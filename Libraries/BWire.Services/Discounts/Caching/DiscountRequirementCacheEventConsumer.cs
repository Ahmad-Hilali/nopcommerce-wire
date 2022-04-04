using BWire.Core.Domain.Discounts;
using BWire.Services.Caching;

namespace BWire.Services.Discounts.Caching
{
    /// <summary>
    /// Represents a discount requirement cache event consumer
    /// </summary>
    public partial class DiscountRequirementCacheEventConsumer : CacheEventConsumer<DiscountRequirement>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(DiscountRequirement entity)
        {
            var cacheKey = _cacheKeyService.PrepareKey(NopDiscountDefaults.DiscountRequirementModelCacheKey, entity.DiscountId);
            Remove(cacheKey);
        }
    }
}
