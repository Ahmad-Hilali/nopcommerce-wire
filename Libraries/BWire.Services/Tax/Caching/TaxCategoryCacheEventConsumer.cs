using BWire.Core.Domain.Tax;
using BWire.Services.Caching;

namespace BWire.Services.Tax.Caching
{
    /// <summary>
    /// Represents a TAX category cache event consumer
    /// </summary>
    public partial class TaxCategoryCacheEventConsumer : CacheEventConsumer<TaxCategory>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(TaxCategory entity)
        {
            Remove(NopTaxDefaults.TaxCategoriesAllCacheKey);
        }
    }
}
