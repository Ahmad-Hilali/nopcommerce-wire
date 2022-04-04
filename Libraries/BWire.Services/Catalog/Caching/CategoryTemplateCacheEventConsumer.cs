using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a category template cache event consumer
    /// </summary>
    public partial class CategoryTemplateCacheEventConsumer : CacheEventConsumer<CategoryTemplate>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(CategoryTemplate entity)
        {
            Remove(NopCatalogDefaults.CategoryTemplatesAllCacheKey);
        }
    }
}
