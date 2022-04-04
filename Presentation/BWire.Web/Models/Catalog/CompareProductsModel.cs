using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Catalog
{
    public partial class CompareProductsModel : BaseNopEntityModel
    {
        public CompareProductsModel()
        {
            Products = new List<ProductOverviewModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }

        public bool IncludeShortDescriptionInCompareProducts { get; set; }
        public bool IncludeFullDescriptionInCompareProducts { get; set; }
    }
}