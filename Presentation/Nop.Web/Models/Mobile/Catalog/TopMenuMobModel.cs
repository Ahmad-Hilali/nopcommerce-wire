using System.Collections.Generic;
using System.Linq;
using Nop.Web.Framework.Models;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class TopMenuMobModel : BaseNopModel
    {
        public TopMenuMobModel()
        {
            Categories = new List<CategorySimpleMobModel>();
            Topics = new List<TopicMobModel>();
        }

        public IList<CategorySimpleMobModel> Categories { get; set; }
        public IList<TopicMobModel> Topics { get; set; }

        public bool BlogEnabled { get; set; }
        public bool NewProductsEnabled { get; set; }
        public bool ForumEnabled { get; set; }

        public bool DisplayHomepageMenuItem { get; set; }
        public bool DisplayNewProductsMenuItem { get; set; }
        public bool DisplayProductSearchMenuItem { get; set; }
        public bool DisplayCustomerInfoMenuItem { get; set; }
        public bool DisplayBlogMenuItem { get; set; }
        public bool DisplayForumsMenuItem { get; set; }
        public bool DisplayContactUsMenuItem { get; set; }

        public bool UseAjaxMenu { get; set; }

        public bool HasOnlyCategories => Categories.Any()
                       && !Topics.Any()
                       && !DisplayHomepageMenuItem
                       && !(DisplayNewProductsMenuItem && NewProductsEnabled)
                       && !DisplayProductSearchMenuItem
                       && !DisplayCustomerInfoMenuItem
                       && !(DisplayBlogMenuItem && BlogEnabled)
                       && !(DisplayForumsMenuItem && ForumEnabled)
                       && !DisplayContactUsMenuItem;

        #region Nested classes

        public class TopicMobModel : BaseNopEntityModel
        {
            public string Name { get; set; }
            public string SeName { get; set; }
        }

        public class CategoryLineMobModel : BaseNopModel
        {
            public int Level { get; set; }
            public bool ResponsiveMobileMenu { get; set; }
            public CategorySimpleMobModel Category { get; set; }
        }

        #endregion
    }
}