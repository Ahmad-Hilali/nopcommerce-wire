using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a BWire news model
    /// </summary>
    public partial class BWireNewsModel : BaseNopModel
    {
        #region Ctor

        public BWireNewsModel()
        {
            Items = new List<BWireNewsDetailsModel>();
        }

        #endregion

        #region Properties

        public List<BWireNewsDetailsModel> Items { get; set; }

        public bool HasNewItems { get; set; }

        public bool HideAdvertisements { get; set; }

        #endregion
    }
}