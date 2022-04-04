using BWire.Services.Customers;
using BWire.Services.Plugins;

namespace BWire.Services.Discounts
{
    /// <summary>
    /// Represents a discount requirement plugin manager implementation
    /// </summary>
    public partial class DiscountPluginManager : PluginManager<IDiscountRequirementRule>, IDiscountPluginManager
    {
        #region Ctor

        public DiscountPluginManager(ICustomerService customerService,
            IPluginService pluginService) : base(customerService, pluginService)
        {
        }

        #endregion
    }
}