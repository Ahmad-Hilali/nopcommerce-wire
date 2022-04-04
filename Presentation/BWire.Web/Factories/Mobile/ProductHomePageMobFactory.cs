using BWire.Core.Domain.Catalog;
using BWire.Services.Catalog;
using BWire.Services.Security;
using BWire.Services.Stores;
using BWire.Web.Models.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace BWire.Web.Factories.Mobile
{
    public class ProductHomePageMobFactory : IProductHomePageMobFactory
    {
        private readonly IAclService _aclService;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IStoreMappingService _storeMappingService;

        public ProductHomePageMobFactory(IAclService aclService,
            IProductModelFactory productModelFactory,
            IProductService productService,
            IStoreMappingService storeMappingService)
        {
            _aclService = aclService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _storeMappingService = storeMappingService;
        }

        public IEnumerable<ProductOverviewModel> GetHomePageProducts(int? productThumbPictureSize)
        {
            var products = _productService.GetAllProductsDisplayedOnHomepage();
            //ACL and store mapping
            products = products.Where(p => _aclService.Authorize(p) && _storeMappingService.Authorize(p)).ToList();
            //availability dates
            products = products.Where(p => _productService.ProductIsAvailable(p)).ToList();

            products = products.Where(p => p.VisibleIndividually).ToList();

            if (!products.Any())
                return null;

            var model = _productModelFactory.PrepareProductOverviewModels(products, true, true, productThumbPictureSize).ToList();

            return model;
        }
    }
}
