using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a manufacturer template cache event consumer
    /// </summary>
    public partial class ManufacturerTemplateCacheEventConsumer : CacheEventConsumer<ManufacturerTemplate>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ManufacturerTemplate entity)
        {
            Remove(NopCatalogDefaults.ManufacturerTemplatesAllCacheKey);
        }
    }
}
