using BWire.Core.Domain.Common;
using BWire.Services.Caching;
using BWire.Services.Customers;

namespace BWire.Services.Common.Caching
{
    /// <summary>
    /// Represents a address cache event consumer
    /// </summary>
    public partial class AddressCacheEventConsumer : CacheEventConsumer<Address>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Address entity)
        {
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerAddressesPrefixCacheKey);
        }
    }
}
