using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product category cache event consumer
    /// </summary>
    public partial class ProductCategoryCacheEventConsumer : CacheEventConsumer<ProductCategory>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductCategory entity)
        {
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductCategoriesByProductPrefixCacheKey, entity.ProductId);
            RemoveByPrefix(prefix);

            RemoveByPrefix(NopCatalogDefaults.CategoryNumberOfProductsPrefixCacheKey);
            
            prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductPricePrefixCacheKey, entity.ProductId);
            RemoveByPrefix(prefix);
        }
    }
}
