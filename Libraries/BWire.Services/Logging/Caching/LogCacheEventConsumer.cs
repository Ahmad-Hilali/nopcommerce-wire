using BWire.Core.Domain.Logging;
using BWire.Services.Caching;

namespace BWire.Services.Logging.Caching
{
    /// <summary>
    /// Represents a log cache event consumer
    /// </summary>
    public partial class LogCacheEventConsumer : CacheEventConsumer<Log>
    {
    }
}
