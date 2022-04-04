using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Boards
{
    public partial class BoardsIndexModel : BaseNopModel
    {
        public BoardsIndexModel()
        {
            ForumGroups = new List<ForumGroupModel>();
        }
        
        public IList<ForumGroupModel> ForumGroups { get; set; }
    }
}