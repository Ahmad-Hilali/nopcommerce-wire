using BWire.Core.Domain.Forums;
using BWire.Services.Caching;

namespace BWire.Services.Forums.Caching
{
    /// <summary>
    /// Represents a forum cache event consumer
    /// </summary>
    public partial class ForumCacheEventConsumer : CacheEventConsumer<Forum>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Forum entity)
        {
            var cacheKey = _cacheKeyService.PrepareKey(NopForumDefaults.ForumAllByForumGroupIdCacheKey, entity.ForumGroupId);
            Remove(cacheKey);
        }
    }
}
