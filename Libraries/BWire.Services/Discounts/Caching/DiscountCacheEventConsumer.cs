using BWire.Core.Domain.Discounts;
using BWire.Services.Caching;

namespace BWire.Services.Discounts.Caching
{
    /// <summary>
    /// Represents a discount cache event consumer
    /// </summary>
    public partial class DiscountCacheEventConsumer : CacheEventConsumer<Discount>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Discount entity)
        {
            RemoveByPrefix(NopDiscountDefaults.DiscountAllPrefixCacheKey);
            var cacheKey = _cacheKeyService.PrepareKey(NopDiscountDefaults.DiscountRequirementModelCacheKey, entity);
            Remove(cacheKey);

            var prefix = _cacheKeyService.PrepareKeyPrefix(NopDiscountDefaults.DiscountCategoryIdsByDiscountPrefixCacheKey, entity);
            RemoveByPrefix(prefix);

            prefix = _cacheKeyService.PrepareKeyPrefix(NopDiscountDefaults.DiscountManufacturerIdsByDiscountPrefixCacheKey, entity);
            RemoveByPrefix(prefix);
        }
    }
}
