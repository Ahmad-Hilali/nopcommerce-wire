using BWire.Core.Domain.Customers;
using BWire.Services.Caching;

namespace BWire.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer customer role mapping cache event consumer
    /// </summary>
    public partial class CustomerCustomerRoleMappingCacheEventConsumer : CacheEventConsumer<CustomerCustomerRoleMapping>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(CustomerCustomerRoleMapping entity)
        {
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerCustomerRolesPrefixCacheKey);
        }
    }
}