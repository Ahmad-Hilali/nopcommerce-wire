using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a warehouse search model
    /// </summary>
    public partial class WarehouseSearchModel : BaseSearchModel
    {
        [NopResourceDisplayName("Admin.Orders.Shipments.List.Warehouse.SearchName")]
        public string SearchName { get; set; }
    }
}