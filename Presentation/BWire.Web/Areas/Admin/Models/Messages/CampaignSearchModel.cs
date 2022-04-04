using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Messages
{
    /// <summary>
    /// Represents a campaign search model
    /// </summary>
    public partial class CampaignSearchModel : BaseSearchModel
    {
        #region Ctor

        public CampaignSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Promotions.Campaigns.List.Stores")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}