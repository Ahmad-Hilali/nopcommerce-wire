using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class PopularProductTagsViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;

        public PopularProductTagsViewComponent(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            var model = _catalogModelFactory.PreparePopularProductTagsModel();

            if (!model.Tags.Any())
                return Content("");

            return View(model);
        }
    }
}
