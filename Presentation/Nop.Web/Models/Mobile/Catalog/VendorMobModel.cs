using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Mobile.Media;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class VendorMobModel : BaseNopEntityModel
    {
        public VendorMobModel()
        {
            PictureModel = new PictureMobModel();
            Products = new List<ProductOverviewMobModel>();
            PagingFilteringContext = new CatalogPagingFilteringMobModel();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }
        public bool AllowCustomersToContactVendors { get; set; }

        public PictureMobModel PictureModel { get; set; }

        public CatalogPagingFilteringMobModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewMobModel> Products { get; set; }
    }
}