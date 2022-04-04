using Microsoft.AspNetCore.Routing;
using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Cms
{
    /// <summary>
    /// Represents a widget model
    /// </summary>
    public partial class WidgetModel : BaseNopModel, IPluginModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.Fields.SystemName")]
        public string SystemName { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.Fields.IsActive")]
        public bool IsActive { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Widgets.Configure")]
        public string ConfigurationUrl { get; set; }

        public string LogoUrl { get; set; }

        public string WidgetViewComponentName { get; set; }

        public RouteValueDictionary WidgetViewComponentArguments { get; set; }

        #endregion
    }
}