using Microsoft.AspNetCore.Mvc;
using BWire.Core.Domain.News;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class NewsRssHeaderLinkViewComponent : NopViewComponent
    {
        private readonly NewsSettings _newsSettings;

        public NewsRssHeaderLinkViewComponent(NewsSettings newsSettings)
        {
            _newsSettings = newsSettings;
        }

        public IViewComponentResult Invoke(int currentCategoryId, int currentProductId)
        {
            if (!_newsSettings.Enabled || !_newsSettings.ShowHeaderRssUrl)
                return Content("");

            return View();
        }
    }
}
