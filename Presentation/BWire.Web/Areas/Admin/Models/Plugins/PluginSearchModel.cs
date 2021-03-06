using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Plugins
{
    /// <summary>
    /// Represents a plugin search model
    /// </summary>
    public partial class PluginSearchModel : BaseSearchModel
    {
        #region Ctor

        public PluginSearchModel()
        {
            AvailableLoadModes = new List<SelectListItem>();
            AvailableGroups = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public int SearchLoadModeId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public string SearchGroup { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Plugins.FriendlyName")]
        public string SearchFriendlyName { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Plugins.Author")]
        public string SearchAuthor { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public IList<SelectListItem> AvailableLoadModes { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public IList<SelectListItem> AvailableGroups { get; set; }

        public bool NeedToRestart { get; set; }

        #endregion
    }
}