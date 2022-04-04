using BWire.Core.Domain.Polls;
using BWire.Services.Caching;

namespace BWire.Services.Polls.Caching
{
    /// <summary>
    /// Represents a poll cache event consumer
    /// </summary>
    public partial class PollCacheEventConsumer : CacheEventConsumer<Poll>
    {
    }
}