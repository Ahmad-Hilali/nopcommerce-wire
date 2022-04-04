using BWire.Core.Domain.Catalog;
using BWire.Services.Caching;

namespace BWire.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product review helpfulness cache event consumer
    /// </summary>
    public partial class ProductReviewHelpfulnessCacheEventConsumer : CacheEventConsumer<ProductReviewHelpfulness>
    {
    }
}
