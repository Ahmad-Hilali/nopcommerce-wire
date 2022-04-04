using BWire.Core.Domain.Localization;
using BWire.Services.Caching;

namespace BWire.Services.Localization.Caching
{
    /// <summary>
    /// Represents a language cache event consumer
    /// </summary>
    public partial class LanguageCacheEventConsumer : CacheEventConsumer<Language>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Language entity)
        {
            Remove(_cacheKeyService.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllPublicCacheKey, entity));
            Remove(_cacheKeyService.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllAdminCacheKey, entity));
            Remove(_cacheKeyService.PrepareKey(NopLocalizationDefaults.LocaleStringResourcesAllCacheKey, entity));

            var prefix = _cacheKeyService.PrepareKeyPrefix(NopLocalizationDefaults.LocaleStringResourcesByResourceNamePrefixCacheKey, entity);
            RemoveByPrefix(prefix);

            RemoveByPrefix(NopLocalizationDefaults.LanguagesAllPrefixCacheKey);
        }
    }
}