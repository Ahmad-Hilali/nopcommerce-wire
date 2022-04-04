using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Blogs
{
    public partial class BlogPostTagModel : BaseNopModel
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}