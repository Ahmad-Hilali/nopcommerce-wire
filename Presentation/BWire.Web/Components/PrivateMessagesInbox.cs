using Microsoft.AspNetCore.Mvc;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class PrivateMessagesInboxViewComponent : NopViewComponent
    {
        private readonly IPrivateMessagesModelFactory _privateMessagesModelFactory;

        public PrivateMessagesInboxViewComponent(IPrivateMessagesModelFactory privateMessagesModelFactory)
        {
            _privateMessagesModelFactory = privateMessagesModelFactory;
        }

        public IViewComponentResult Invoke(int pageNumber, string tab)
        {
            var model = _privateMessagesModelFactory.PrepareInboxModel(pageNumber, tab);
            return View(model);
        }
    }
}
