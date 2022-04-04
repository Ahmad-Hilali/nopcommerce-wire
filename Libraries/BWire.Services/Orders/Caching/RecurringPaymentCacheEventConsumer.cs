using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents a recurring payment cache event consumer
    /// </summary>
    public partial class RecurringPaymentCacheEventConsumer : CacheEventConsumer<RecurringPayment>
    { 
    }
}
