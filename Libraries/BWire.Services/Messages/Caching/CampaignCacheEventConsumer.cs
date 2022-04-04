using BWire.Core.Domain.Messages;
using BWire.Services.Caching;

namespace BWire.Services.Messages.Caching
{
    /// <summary>
    /// Represents a campaign cache event consumer
    /// </summary>
    public partial class CampaignCacheEventConsumer : CacheEventConsumer<Campaign>
    {
    }
}
