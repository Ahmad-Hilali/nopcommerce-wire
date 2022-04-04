using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product tag search model
    /// </summary>
    public partial class ProductTagSearchModel : BaseSearchModel
    {
        [NopResourceDisplayName("Admin.Catalog.ProductTags.Fields.SearchTagName")]
        public string SearchTagName { get; set; }
    }
}