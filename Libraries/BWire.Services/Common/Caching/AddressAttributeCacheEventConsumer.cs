using BWire.Core.Domain.Common;
using BWire.Services.Caching;

namespace BWire.Services.Common.Caching
{
    /// <summary>
    /// Represents a address attribute cache event consumer
    /// </summary>
    public partial class AddressAttributeCacheEventConsumer : CacheEventConsumer<AddressAttribute>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(AddressAttribute entity)
        {
            Remove(NopCommonDefaults.AddressAttributesAllCacheKey);

            var cacheKey = _cacheKeyService.PrepareKey(NopCommonDefaults.AddressAttributeValuesAllCacheKey, entity);
            Remove(cacheKey);
        }
    }
}
