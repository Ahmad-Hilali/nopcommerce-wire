using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product model to add to the manufacturer
    /// </summary>
    public partial class AddProductToManufacturerModel : BaseNopModel
    {
        #region Ctor

        public AddProductToManufacturerModel()
        {
            SelectedProductIds = new List<int>();
        }
        #endregion

        #region Properties

        public int ManufacturerId { get; set; }

        public IList<int> SelectedProductIds { get; set; }

        #endregion
    }
}