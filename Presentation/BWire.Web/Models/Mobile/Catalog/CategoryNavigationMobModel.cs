using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Mobile.Catalog
{
    public partial class CategoryNavigationMobModel : BaseNopModel
    {
        public CategoryNavigationMobModel()
        {
            Categories = new List<CategorySimpleMobModel>();
        }

        public int CurrentCategoryId { get; set; }
        public List<CategorySimpleMobModel> Categories { get; set; }

        #region Nested classes

        public class CategoryLineMobModel : BaseNopModel
        {
            public int CurrentCategoryId { get; set; }
            public CategorySimpleMobModel Category { get; set; }
        }

        #endregion
    }
}