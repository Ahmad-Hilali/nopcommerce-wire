using BWire.Core.Domain.Logging;
using BWire.Services.Caching;

namespace BWire.Services.Logging.Caching
{
    /// <summary>
    /// Represents an activity log cache event consumer
    /// </summary>
    public partial class ActivityLogCacheEventConsumer : CacheEventConsumer<ActivityLog>
    {
    }
}