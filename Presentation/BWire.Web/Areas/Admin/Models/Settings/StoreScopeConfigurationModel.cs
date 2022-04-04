using System.Collections.Generic;
using BWire.Web.Areas.Admin.Models.Stores;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a store scope configuration model
    /// </summary>
    public partial class StoreScopeConfigurationModel : BaseNopModel
    {
        #region Ctor

        public StoreScopeConfigurationModel()
        {
            Stores = new List<StoreModel>();
        }

        #endregion

        #region Properties

        public int StoreId { get; set; }

        public IList<StoreModel> Stores { get; set; }

        #endregion
    }
}