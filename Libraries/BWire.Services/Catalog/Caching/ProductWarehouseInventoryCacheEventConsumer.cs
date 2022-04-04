using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product warehouse inventory cache event consumer
    /// </summary>
    public partial class ProductWarehouseInventoryCacheEventConsumer : CacheEventConsumer<ProductWarehouseInventory>
    {
    }
}
