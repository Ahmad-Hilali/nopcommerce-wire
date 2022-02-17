using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.ShoppingCart
{
    public class UpdatedCartMobModel
    {
        public UpdatedCartMobModel()
        {
            Items = new List<UpdatedItemsInCart>();
        }
        public IList<UpdatedItemsInCart> Items { get; set; }
    }
}
