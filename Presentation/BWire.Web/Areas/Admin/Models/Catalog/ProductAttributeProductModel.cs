using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a model of products that use the product attribute
    /// </summary>
    public partial class ProductAttributeProductModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Product")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Published")]
        public bool Published { get; set; }

        #endregion
    }
}