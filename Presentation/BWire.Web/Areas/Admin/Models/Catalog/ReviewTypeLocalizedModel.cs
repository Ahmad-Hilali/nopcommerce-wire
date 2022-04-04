using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a review type localized model
    /// </summary>
    public partial class ReviewTypeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
        public string Description { get; set; }
    }
}
