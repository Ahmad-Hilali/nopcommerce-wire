using BWire.Core.Domain.Directory;
using BWire.Services.Caching;

namespace BWire.Services.Directory.Caching
{
    /// <summary>
    /// Represents a state province cache event consumer
    /// </summary>
    public partial class StateProvinceCacheEventConsumer : CacheEventConsumer<StateProvince>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(StateProvince entity)
        {
            RemoveByPrefix(NopDirectoryDefaults.StateProvincesPrefixCacheKey);
        }
    }
}
