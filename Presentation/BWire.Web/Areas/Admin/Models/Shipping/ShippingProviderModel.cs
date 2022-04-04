using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a shipping provider model
    /// </summary>
    public partial class ShippingProviderModel : BaseNopModel, IPluginModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.IsActive")]
        public bool IsActive { get; set; }
        
        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Fields.Logo")]
        public string LogoUrl { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Shipping.Providers.Configure")]
        public string ConfigurationUrl { get; set; }

        #endregion
    }
}