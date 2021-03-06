using Microsoft.AspNetCore.Mvc;
using BWire.Core.Domain.Catalog;
using BWire.Services.Configuration;
using BWire.Services.Stores;
using BWire.Web.Framework.Components;

namespace BWire.Web.Areas.Admin.Components
{
    public class MultistoreDisabledWarningViewComponent : NopViewComponent
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;

        public MultistoreDisabledWarningViewComponent(CatalogSettings catalogSettings,
            ISettingService settingService,
            IStoreService storeService)
        {
            _catalogSettings = catalogSettings;
            _settingService = settingService;
            _storeService = storeService;
        }

        public IViewComponentResult Invoke()
        {

            //action displaying notification (warning) to a store owner that "limit per store" feature is ignored

            //default setting
            var enabled = _catalogSettings.IgnoreStoreLimitations;
            if (!enabled)
            {
                //overridden settings
                var stores = _storeService.GetAllStores();
                foreach (var store in stores)
                {
                    var catalogSettings = _settingService.LoadSetting<CatalogSettings>(store.Id);
                    enabled = catalogSettings.IgnoreStoreLimitations;

                    if (enabled)
                        break;
                }
            }

            //This setting is disabled. No warnings.
            if (!enabled)
                return Content("");

            return View();
        }
    }
}
