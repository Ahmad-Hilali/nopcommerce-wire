using BWire.Web.Areas.Admin.Models.Plugins.Marketplace;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Plugins
{
    /// <summary>
    /// Represents a plugins configuration model
    /// </summary>
    public partial class PluginsConfigurationModel : BaseNopModel
    {
        #region Ctor

        public PluginsConfigurationModel()
        {
            PluginsLocal = new PluginSearchModel();
            AllPluginsAndThemes = new OfficialFeedPluginSearchModel();
        }

        #endregion

        #region Properties

        public PluginSearchModel PluginsLocal { get; set; }

        public OfficialFeedPluginSearchModel AllPluginsAndThemes { get; set; }

        #endregion
    }
}
