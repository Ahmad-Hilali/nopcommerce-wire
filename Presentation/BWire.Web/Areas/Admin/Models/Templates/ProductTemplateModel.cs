using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a product template model
    /// </summary>
    public partial class ProductTemplateModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.System.Templates.Product.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Product.ViewPath")]
        public string ViewPath { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Product.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.System.Templates.Product.IgnoredProductTypes")]
        public string IgnoredProductTypes { get; set; }

        #endregion
    }
}