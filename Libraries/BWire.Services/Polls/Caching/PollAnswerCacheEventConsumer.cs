using BWire.Core.Domain.Polls;
using BWire.Services.Caching;

namespace BWire.Services.Polls.Caching
{
    /// <summary>
    /// Represents a poll answer cache event consumer
    /// </summary>
    public partial class PollAnswerCacheEventConsumer : CacheEventConsumer<PollAnswer>
    {
    }
}