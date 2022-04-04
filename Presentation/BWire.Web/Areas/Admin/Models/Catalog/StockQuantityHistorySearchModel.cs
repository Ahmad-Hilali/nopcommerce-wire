using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a stock quantity history search model
    /// </summary>
    public partial class StockQuantityHistorySearchModel : BaseSearchModel
    {
        #region Ctor

        public StockQuantityHistorySearchModel()
        {
            AvailableWarehouses = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.List.SearchWarehouse")]
        public int WarehouseId { get; set; }

        public IList<SelectListItem> AvailableWarehouses { get; set; }

        #endregion
    }
}