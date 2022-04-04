using BWire.Core.Domain.Customers;
using BWire.Services.Caching;

namespace BWire.Services.Customers.Caching
{
    /// <summary>
    /// Represents a reward point history cache event consumer
    /// </summary>
    public partial class RewardPointsHistoryCacheEventConsumer : CacheEventConsumer<RewardPointsHistory>
    {
    }
}
