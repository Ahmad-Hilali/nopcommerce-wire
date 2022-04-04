using BWire.Core.Domain.Customers;
using BWire.Services.Caching;

namespace BWire.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer role cache event consumer
    /// </summary>
    public partial class CustomerRoleCacheEventConsumer : CacheEventConsumer<CustomerRole>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(CustomerRole entity)
        {
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerRolesPrefixCacheKey);
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerCustomerRolesPrefixCacheKey);
        }
    }
}
