using Microsoft.AspNetCore.Mvc;
using BWire.Core.Domain.Blogs;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class BlogRssHeaderLinkViewComponent : NopViewComponent
    {
        private readonly BlogSettings _blogSettings;

        public BlogRssHeaderLinkViewComponent(BlogSettings blogSettings)
        {
            _blogSettings = blogSettings;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_blogSettings.Enabled || !_blogSettings.ShowHeaderRssUrl)
                return Content("");

            return View();
        }
    }
}
