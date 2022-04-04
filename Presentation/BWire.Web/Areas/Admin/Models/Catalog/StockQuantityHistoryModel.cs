using System;
using System.ComponentModel.DataAnnotations;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a stock quantity history model
    /// </summary>
    public partial class StockQuantityHistoryModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Warehouse")]
        public string WarehouseName { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Combination")]
        public string AttributeCombination { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.QuantityAdjustment")]
        public int QuantityAdjustment { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Message")]
        public string Message { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.CreatedOn")]
        [UIHint("DecimalNullable")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}