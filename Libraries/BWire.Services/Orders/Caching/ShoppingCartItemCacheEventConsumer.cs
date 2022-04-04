using BWire.Core.Domain.Orders;
using BWire.Services.Caching;

namespace BWire.Services.Orders.Caching
{
    /// <summary>
    /// Represents a shopping cart item cache event consumer
    /// </summary>
    public partial class ShoppingCartItemCacheEventConsumer : CacheEventConsumer<ShoppingCartItem>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ShoppingCartItem entity)
        {
            RemoveByPrefix(NopOrderDefaults.ShoppingCartPrefixCacheKey);
        }
    }
}
