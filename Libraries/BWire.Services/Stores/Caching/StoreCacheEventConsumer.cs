using BWire.Core.Domain.Stores;
using BWire.Services.Caching;
using BWire.Services.Localization;
using BWire.Services.Orders;

namespace BWire.Services.Stores.Caching
{
    /// <summary>
    /// Represents a store cache event consumer
    /// </summary>
    public partial class StoreCacheEventConsumer : CacheEventConsumer<Store>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Store entity)
        {
            Remove(NopStoreDefaults.StoresAllCacheKey);
            RemoveByPrefix(NopOrderDefaults.ShoppingCartPrefixCacheKey);

            var prefix = _cacheKeyService.PrepareKeyPrefix(NopLocalizationDefaults.LanguagesByStoreIdPrefixCacheKey, entity);

            RemoveByPrefix(prefix);
        }
    }
}
