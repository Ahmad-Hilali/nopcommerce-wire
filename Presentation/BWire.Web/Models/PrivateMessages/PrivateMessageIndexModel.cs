using BWire.Web.Framework.Models;

namespace BWire.Web.Models.PrivateMessages
{
    public partial class PrivateMessageIndexModel : BaseNopModel
    {
        public int InboxPage { get; set; }
        public int SentItemsPage { get; set; }
        public bool SentItemsTabSelected { get; set; }
    }
}