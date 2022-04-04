using BWire.Core.Domain.Discounts;
using BWire.Services.Caching;

namespace BWire.Services.Discounts.Caching
{
    /// <summary>
    /// Represents a discount-manufacturer mapping cache event consumer
    /// </summary>
    public partial class DiscountManufacturerMappingCacheEventConsumer : CacheEventConsumer<DiscountManufacturerMapping>
    {
    }
}