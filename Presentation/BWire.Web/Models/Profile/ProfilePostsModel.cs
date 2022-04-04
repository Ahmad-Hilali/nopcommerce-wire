using System.Collections.Generic;
using BWire.Web.Framework.Models;
using BWire.Web.Models.Common;

namespace BWire.Web.Models.Profile
{
    public partial class ProfilePostsModel : BaseNopModel
    {
        public IList<PostsModel> Posts { get; set; }
        public PagerModel PagerModel { get; set; }
    }
}