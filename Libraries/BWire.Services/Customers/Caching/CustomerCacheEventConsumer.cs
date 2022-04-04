using BWire.Core.Domain.Customers;
using BWire.Services.Caching;
using BWire.Services.Events;
using BWire.Services.Orders;

namespace BWire.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer cache event consumer
    /// </summary>
    public partial class CustomerCacheEventConsumer : CacheEventConsumer<Customer>, IConsumer<CustomerPasswordChangedEvent>
    {
        #region Methods

        /// <summary>
        /// Handle password changed event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public void HandleEvent(CustomerPasswordChangedEvent eventMessage)
        {
            Remove(_cacheKeyService.PrepareKey(NopCustomerServicesDefaults.CustomerPasswordLifetimeCacheKey, eventMessage.Password.CustomerId));
        }

        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Customer entity)
        {
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerCustomerRolesPrefixCacheKey);
            RemoveByPrefix(NopCustomerServicesDefaults.CustomerAddressesPrefixCacheKey);
            RemoveByPrefix(NopOrderDefaults.ShoppingCartPrefixCacheKey);
        }

        #endregion
    }
}