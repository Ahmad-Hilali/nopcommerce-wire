using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product attribute mapping search model
    /// </summary>
    public partial class ProductAttributeMappingSearchModel : BaseSearchModel
    {
        #region Properties

        public int ProductId { get; set; }

        #endregion
    }
}