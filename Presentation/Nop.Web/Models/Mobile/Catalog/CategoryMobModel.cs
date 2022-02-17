using Nop.Web.Models.Mobile.Media;
using System.Collections.Generic;

namespace Nop.Web.Models.Mobile.Catalog
{
    public class CategoryMobModel
    {
        public CategoryMobModel()
        {
            Picture = new PictureMobModel();
            FeaturedProducts = new List<ProductOverviewMobModel>();
            Products = new List<ProductOverviewMobModel>();
            PagingFilteringContext = new CatalogPagingFilteringMobModel();
            SubCategories = new List<CategorySimpleMobModel>();
            CategoryBreadcrumb = new List<CategoryMobModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public PictureMobModel Picture { get; set; }

        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }

        public CatalogPagingFilteringMobModel PagingFilteringContext { get; set; }

        public bool DisplayCategoryBreadcrumb { get; set; }
        public IList<CategoryMobModel> CategoryBreadcrumb { get; set; }

        public IList<CategorySimpleMobModel> SubCategories { get; set; }

        public IList<ProductOverviewMobModel> FeaturedProducts { get; set; }
        public IList<ProductOverviewMobModel> Products { get; set; }
    }
}
