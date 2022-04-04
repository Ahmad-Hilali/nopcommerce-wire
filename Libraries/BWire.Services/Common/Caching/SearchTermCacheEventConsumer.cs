using BWire.Core.Domain.Common;
using BWire.Services.Caching;

namespace BWire.Services.Common.Caching
{
    /// <summary>
    /// Represents a search term cache event consumer
    /// </summary>
    public partial class SearchTermCacheEventConsumer : CacheEventConsumer<SearchTerm>
    {
    }
}
