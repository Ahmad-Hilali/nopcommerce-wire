using BWire.Core.Domain.Common;
using BWire.Services.Caching;

namespace BWire.Services.Common.Caching
{
    /// <summary>
    /// Represents a generic attribute cache event consumer
    /// </summary>
    public partial class GenericAttributeCacheEventConsumer : CacheEventConsumer<GenericAttribute>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(GenericAttribute entity)
        {
            var cacheKey = _cacheKeyService.PrepareKey(NopCommonDefaults.GenericAttributeCacheKey, entity.EntityId, entity.KeyGroup);
            Remove(cacheKey);
        }
    }
}
