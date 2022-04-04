using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a review type cache event consumer
    /// </summary>
    public partial class ReviewTypeCacheEventConsumer : CacheEventConsumer<ReviewType>
    {
        /// <summary>
        /// entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected override void ClearCache(ReviewType entity, EntityEventType entityEventType)
        {
            if (entityEventType == EntityEventType.Delete)
                RemoveByPrefix(NopCatalogDefaults.ProductReviewReviewTypeMappingAllPrefixCacheKey);

            Remove(NopCatalogDefaults.ReviewTypeAllCacheKey);
        }
    }
}
