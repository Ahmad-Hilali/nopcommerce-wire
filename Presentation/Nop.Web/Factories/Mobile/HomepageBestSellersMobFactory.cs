using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching;
using Nop.Services.Catalog;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Infrastructure.Cache;
using Nop.Web.Models.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Web.Factories.Mobile
{
    public class HomepageBestSellersMobFactory : IHomepageBestSellersMobFactory
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICacheKeyService _cacheKeyService;
        private readonly IOrderReportService _orderReportService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;

        public HomepageBestSellersMobFactory(CatalogSettings catalogSettings,
            IAclService aclService,
            ICacheKeyService cacheKeyService,
            IOrderReportService orderReportService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _cacheKeyService = cacheKeyService;
            _orderReportService = orderReportService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
        }
        public IEnumerable<ProductOverviewModel> GetHomepageBestSellers(int? productThumbPictureSize)
        {
            if (!_catalogSettings.ShowBestsellersOnHomepage || _catalogSettings.NumberOfBestsellersOnHomepage == 0)
                return null;

            //load and cache report
            var report = _staticCacheManager.Get(_cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.HomepageBestsellersIdsKey, _storeContext.CurrentStore),
                () => _orderReportService.BestSellersReport(
                        storeId: _storeContext.CurrentStore.Id,
                        pageSize: _catalogSettings.NumberOfBestsellersOnHomepage)
                    .ToList());

            //load products
            var products = _productService.GetProductsByIds(report.Select(x => x.ProductId).ToArray());
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            if (!products.Any())
                return null;

            //prepare model
            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();
            return model;

        }
    }
}
