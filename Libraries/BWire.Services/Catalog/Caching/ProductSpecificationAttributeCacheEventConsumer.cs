using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product specification attribute cache event consumer
    /// </summary>
    public partial class ProductSpecificationAttributeCacheEventConsumer : CacheEventConsumer<ProductSpecificationAttribute>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductSpecificationAttribute entity)
        {
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductSpecificationAttributeAllByProductIdPrefixCacheKey, entity.ProductId);
            RemoveByPrefix(prefix);
        }
    }
}
