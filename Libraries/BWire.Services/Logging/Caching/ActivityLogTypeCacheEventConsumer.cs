using BWire.Core.Domain.Logging;
using BWire.Services.Caching;

namespace BWire.Services.Logging.Caching
{
    /// <summary>
    /// Represents a activity log type cache event consumer
    /// </summary>
    public partial class ActivityLogTypeCacheEventConsumer : CacheEventConsumer<ActivityLogType>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ActivityLogType entity)
        {
            Remove(NopLoggingDefaults.ActivityTypeAllCacheKey);
        }
    }
}
