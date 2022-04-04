using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BWire.Core.Domain.Catalog;
using BWire.Web.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Components
{
    public class ManufacturerNavigationViewComponent : NopViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly ICatalogModelFactory _catalogModelFactory;

        public ManufacturerNavigationViewComponent(CatalogSettings catalogSettings, ICatalogModelFactory catalogModelFactory)
        {
            _catalogSettings = catalogSettings;
            _catalogModelFactory = catalogModelFactory;
        }

        public IViewComponentResult Invoke(int currentManufacturerId)
        {
            if (_catalogSettings.ManufacturersBlockItemsToDisplay == 0)
                return Content("");

            var model = _catalogModelFactory.PrepareManufacturerNavigationModel(currentManufacturerId);
            if (!model.Manufacturers.Any())
                return Content("");

            return View(model);
        }
    }
}
