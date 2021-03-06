using System.Collections.Generic;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a review type model
    /// </summary>
    public partial class ReviewTypeModel : BaseNopEntityModel, ILocalizedModel<ReviewTypeLocalizedModel>
    {
        #region Ctor

        public ReviewTypeModel()
        {
            Locales = new List<ReviewTypeLocalizedModel>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
        public string Description { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.VisibleToAllCustomers")]
        public bool VisibleToAllCustomers { get; set; }

        public IList<ReviewTypeLocalizedModel> Locales { get; set; }

        #endregion
    }
}
