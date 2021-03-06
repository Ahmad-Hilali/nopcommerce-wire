using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Mobile.Catalog
{
    public partial class ProductsByTagMobModel : BaseNopEntityModel
    {
        public ProductsByTagMobModel()
        {
            Products = new List<ProductOverviewMobModel>();
            PagingFilteringContext = new CatalogPagingFilteringMobModel();
        }

        public string TagName { get; set; }
        public string TagSeName { get; set; }
        
        public CatalogPagingFilteringMobModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewMobModel> Products { get; set; }
    }
}