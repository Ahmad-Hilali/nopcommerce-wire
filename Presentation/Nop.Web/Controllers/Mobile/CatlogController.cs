using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories.Mobile;
using Nop.Web.Models.Mobile.Catalog;
using System.Linq;
using System.Collections.Generic;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatlogController : ControllerBase
    {
        #region Fields

        private readonly CatalogSettings _catalogSettings;
        private readonly IAclService _aclService;
        private readonly ICatalogMobFactory _catalogModelFactory;
        private readonly ICategoryService _categoryService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPermissionService _permissionService;
        private readonly IProductModelMobFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly MediaSettings _mediaSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion
        #region Ctor

        public CatlogController(CatalogSettings catalogSettings,
            IAclService aclService,
            ICatalogMobFactory catalogModelFactory,
            ICategoryService categoryService,
            ICustomerActivityService customerActivityService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            IPermissionService permissionService,
            IProductModelMobFactory productModelFactory,
            IProductService productService,
            IProductTagService productTagService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext,
            MediaSettings mediaSettings,
            VendorSettings vendorSettings)
        {
            _catalogSettings = catalogSettings;
            _aclService = aclService;
            _catalogModelFactory = catalogModelFactory;
            _categoryService = categoryService;
            _customerActivityService = customerActivityService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _permissionService = permissionService;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _vendorSettings = vendorSettings;
        }

        #endregion
        #region Categories
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts(int categoryId, int pageNumber = 1, int pageSize = 5, int orderBy = 0)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null || category.Deleted)
                return BadRequest();
            var notAvailable =
                //published?
                !category.Published ||
                //ACL (access control list) 
                !_aclService.Authorize(category) ||
                //Store mapping
                !_storeMappingService.Authorize(category);
            //Check whether the current user has a "Manage categories" permission (usually a store owner)
            //We should allows him (her) to use "Preview" functionality
            var hasAdminAccess = _permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageCategories);
            if (notAvailable && !hasAdminAccess)
                return Unauthorized();
            var model = _catalogModelFactory.PrepareProducts(new List<int>{ categoryId}, (ProductSortingEnum)orderBy, new List<int> { }, pageNumber, pageSize);
            if (!model.Any())
                return NotFound();
            return Ok(new { Products = model, Count = model.Count});
        }
        [HttpGet]
        [Route("GetGategoriesNavigation")]
        public IActionResult GetGategoriesNavigation(int currentCategoryId, int currentProductId = 0)
        {
            var model = _catalogModelFactory.PrepareCategoryNavigationModel(currentCategoryId, currentProductId);
            if (model == null)
                return NotFound();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetGategories")]
        public IActionResult GetGategories()
        {
            var model = _catalogModelFactory.PrepareCategories();
            if (!model.Any())
                return NotFound();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetManufacturersNavigation")]
        public IActionResult GetManufacturersNavigation(int currentManufacturerId = 0,int ItemsToDisplayCount = 2)
        {
            if (ItemsToDisplayCount == 0)
                return NoContent();

            var model = _catalogModelFactory.PrepareManufacturerNavigationModel(currentManufacturerId, ItemsToDisplayCount);
            if (!model.Manufacturers.Any())
                return NoContent();

            return Ok(model);
        }
        [HttpGet]
        [Route("GetVendorsNavigation")]
        public IActionResult GetVendorsNavigation(int ItemsToDisplayCount = 0)
        {
            if (ItemsToDisplayCount == 0)
                return NoContent();

            var model = _catalogModelFactory.PrepareVendorNavigationModel(ItemsToDisplayCount);
            if (!model.Vendors.Any())
                return NoContent();

            return Ok(model);
        }
        [HttpGet]
        //[IgnoreAntiforgeryToken]
        [Route("GetProductTags")]
        public IActionResult GetProductTags()
        {
            var model = _catalogModelFactory.PreparePopularProductTagsModel();

            if (!model.Tags.Any())
                return NoContent();

            return Ok(model);
        }
        [HttpGet]
        [Route("GetSortingOptions")]
        public IActionResult GetSortingOptions()
        {
            var model = _catalogModelFactory.GetSortingOption();

            if (!model.Any())
                return NoContent();

            return Ok(model);
        }
        [HttpGet]
        [Route("GetViewModes")]
        public IActionResult GetViewModes()
        {
            var model = _catalogModelFactory.GetViewModes();

            if (!model.Any())
                return NoContent();

            return Ok(model);
        }
        #endregion
    }
}
