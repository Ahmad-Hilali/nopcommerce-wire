using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a manufacturer model to add to the discount
    /// </summary>
    public partial class AddManufacturerToDiscountModel : BaseNopModel
    {
        #region Ctor

        public AddManufacturerToDiscountModel()
        {
            SelectedManufacturerIds = new List<int>();
        }
        #endregion

        #region Properties

        public int DiscountId { get; set; }

        public IList<int> SelectedManufacturerIds { get; set; }

        #endregion
    }
}