using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents an associated product search model
    /// </summary>
    public partial class AssociatedProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int ProductId { get; set; }

        #endregion
    }
}