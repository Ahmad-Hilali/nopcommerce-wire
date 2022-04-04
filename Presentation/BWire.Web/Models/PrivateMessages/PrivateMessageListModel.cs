using System.Collections.Generic;
using BWire.Web.Framework.Models;
using BWire.Web.Models.Common;

namespace BWire.Web.Models.PrivateMessages
{
    public partial class PrivateMessageListModel : BaseNopModel
    {
        public IList<PrivateMessageModel> Messages { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}