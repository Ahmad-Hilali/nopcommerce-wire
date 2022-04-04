using BWire.Web.Areas.Admin.Models.ShoppingCart;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer shopping cart list model
    /// </summary>
    public partial class CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
    {
    }
}