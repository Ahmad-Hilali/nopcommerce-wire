using BWire.Core.Domain.Forums;
using BWire.Services.Caching;

namespace BWire.Services.Forums.Caching
{
    /// <summary>
    /// Represents a forum subscription cache event consumer
    /// </summary>
    public partial class ForumSubscriptionCacheEventConsumer : CacheEventConsumer<ForumSubscription>
    {
    }
}
