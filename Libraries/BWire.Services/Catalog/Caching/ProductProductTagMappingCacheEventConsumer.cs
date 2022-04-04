using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product-product tag mapping  cache event consumer
    /// </summary>
    public partial class ProductProductTagMappingCacheEventConsumer : CacheEventConsumer<ProductProductTagMapping>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductProductTagMapping entity)
        {
            Remove(_cacheKeyService.PrepareKey(NopCatalogDefaults.ProductTagAllByProductIdCacheKey, entity.ProductId));
        }
    }
}