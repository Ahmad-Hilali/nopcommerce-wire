using Microsoft.AspNetCore.Mvc;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class ForumBreadcrumbViewComponent : NopViewComponent
    {
        private readonly IForumModelFactory _forumModelFactory;

        public ForumBreadcrumbViewComponent(IForumModelFactory forumModelFactory)
        {
            _forumModelFactory = forumModelFactory;
        }

        public IViewComponentResult Invoke(int? forumGroupId, int? forumId, int? forumTopicId)
        {
            var model = _forumModelFactory.PrepareForumBreadcrumbModel(forumGroupId, forumId, forumTopicId);
            return View(model);
        }
    }
}
