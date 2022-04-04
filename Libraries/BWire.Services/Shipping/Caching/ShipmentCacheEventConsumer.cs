using BWire.Core.Domain.Shipping;
using BWire.Services.Caching;

namespace BWire.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a shipment cache event consumer
    /// </summary>
    public partial class ShipmentCacheEventConsumer : CacheEventConsumer<Shipment>
    {
    }
}