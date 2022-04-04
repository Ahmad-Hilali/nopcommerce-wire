using BWire.Core.Domain.Customers;
using BWire.Services.Caching;

namespace BWire.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer address mapping cache event consumer
    /// </summary>
    public partial class CustomerAddressMappingCacheEventConsumer : CacheEventConsumer<CustomerAddressMapping>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(CustomerAddressMapping entity)
        {
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerAddressesPrefixCacheKey);
        }
    }
}