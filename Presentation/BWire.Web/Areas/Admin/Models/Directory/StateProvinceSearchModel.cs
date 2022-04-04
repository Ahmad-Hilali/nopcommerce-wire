using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a state and province search model
    /// </summary>
    public partial class StateProvinceSearchModel : BaseSearchModel
    {
        #region Properties

        public int CountryId { get; set; }

        #endregion
    }
}