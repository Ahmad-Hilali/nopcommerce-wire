using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product picture mapping cache event consumer
    /// </summary>
    public partial class ProductPictureCacheEventConsumer : CacheEventConsumer<ProductPicture>
    {
    }
}
