using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product template cache event consumer
    /// </summary>
    public partial class ProductTemplateCacheEventConsumer : CacheEventConsumer<ProductTemplate>
    {
        /// <summary>
        /// entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected override void ClearCache(ProductTemplate entity, EntityEventType entityEventType)
        {
            Remove(NopCatalogDefaults.ProductTemplatesAllCacheKey);
        }
    }
}
