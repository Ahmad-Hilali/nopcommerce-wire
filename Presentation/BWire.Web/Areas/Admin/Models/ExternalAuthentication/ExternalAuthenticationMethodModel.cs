using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.ExternalAuthentication
{
    /// <summary>
    /// Represents an external authentication method model
    /// </summary>
    public partial class ExternalAuthenticationMethodModel : BaseNopModel, IPluginModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Configure")]
        public string ConfigurationUrl { get; set; }

        public string LogoUrl { get; set; }

        #endregion
    }
}