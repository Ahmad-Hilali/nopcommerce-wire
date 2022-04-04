using BWire.Core.Domain.Gdpr;
using BWire.Services.Caching;

namespace BWire.Services.Gdpr.Caching
{
    /// <summary>
    /// Represents a GDPR log cache event consumer
    /// </summary>
    public partial class GdprLogCacheEventConsumer : CacheEventConsumer<GdprLog>
    {
    }
}
