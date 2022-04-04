using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Web.Framework.Models;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace BWire.Web.Areas.Admin.Models.Polls
{
    /// <summary>
    /// Represents a poll search model
    /// </summary>
    public partial class PollSearchModel : BaseSearchModel
    {
        #region Ctor

        public PollSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Polls.List.SearchStore")]
        public int SearchStoreId { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}