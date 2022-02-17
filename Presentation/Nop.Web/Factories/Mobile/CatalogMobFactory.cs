using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Caching;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Seo;
using Nop.Services.Topics;
using Nop.Services.Vendors;
using Nop.Web.Framework.Events;
using Nop.Web.Infrastructure.Cache;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Media;
using Nop.Web.Models.Mobile.Catalog;
using Nop.Web.Models.Mobile.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Nop.Web.Factories.Mobile
{
    public partial class CatalogMobFactory : ICatalogMobFactory
    {
        #region Fields

        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly BlogSettings _blogSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly DisplayDefaultMenuItemSettings _displayDefaultMenuItemSettings;
        private readonly ForumSettings _forumSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ICacheKeyService _cacheKeyService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryTemplateService _categoryTemplateService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IManufacturerTemplateService _manufacturerTemplateService;
        private readonly IPictureService _pictureService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IProductModelMobFactory _productModelFactory;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly ISearchTermService _searchTermService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        private readonly ITopicService _topicService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorService _vendorService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly MediaSettings _mediaSettings;
        private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CatalogMobFactory(BlogSettings blogSettings,
            CatalogSettings catalogSettings,
            DisplayDefaultMenuItemSettings displayDefaultMenuItemSettings,
            ForumSettings forumSettings,
            IActionContextAccessor actionContextAccessor,
            ICacheKeyService cacheKeyService,
            ICategoryService categoryService,
            ICategoryTemplateService categoryTemplateService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            IHttpContextAccessor httpContextAccessor,
            ILocalizationService localizationService,
            IManufacturerService manufacturerService,
            IManufacturerTemplateService manufacturerTemplateService,
            IPictureService pictureService,
            IPriceFormatter priceFormatter,
            IProductModelMobFactory productModelFactory,
            IProductService productService,
            IProductTagService productTagService,
            ISearchTermService searchTermService,
            ISpecificationAttributeService specificationAttributeService,
            IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            ITopicService topicService,
            IUrlHelperFactory urlHelperFactory,
            IUrlRecordService urlRecordService,
            IVendorService vendorService,
            IWebHelper webHelper,
            IWorkContext workContext,
            MediaSettings mediaSettings,
            VendorSettings vendorSettings,
            ICatalogModelFactory catalogModelFactory)
        {
            _blogSettings = blogSettings;
            _catalogSettings = catalogSettings;
            _displayDefaultMenuItemSettings = displayDefaultMenuItemSettings;
            _forumSettings = forumSettings;
            _actionContextAccessor = actionContextAccessor;
            _cacheKeyService = cacheKeyService;
            _categoryService = categoryService;
            _categoryTemplateService = categoryTemplateService;
            _currencyService = currencyService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _httpContextAccessor = httpContextAccessor;
            _localizationService = localizationService;
            _manufacturerService = manufacturerService;
            _manufacturerTemplateService = manufacturerTemplateService;
            _pictureService = pictureService;
            _priceFormatter = priceFormatter;
            _productModelFactory = productModelFactory;
            _productService = productService;
            _productTagService = productTagService;
            _searchTermService = searchTermService;
            _specificationAttributeService = specificationAttributeService;
            _staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            _topicService = topicService;
            _urlHelperFactory = urlHelperFactory;
            _urlRecordService = urlRecordService;
            _vendorService = vendorService;
            _webHelper = webHelper;
            _workContext = workContext;
            _mediaSettings = mediaSettings;
            _vendorSettings = vendorSettings;
            _catalogModelFactory = catalogModelFactory;
        }

        #endregion

        #region Categories

        /// <summary>
        /// Prepare homepage category models
        /// </summary>
        /// <returns>List of homepage category models</returns>
        public List<CategoryMobModel> PrepareHomepageCategoryModels()
        {
            var model = _catalogModelFactory.PrepareHomepageCategoryModels().Select(x => new CategoryMobModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //SubCategories = GetSubCategories(x.SubCategories),
                Picture = x.PictureModel == null ? null : new PictureMobModel()
                {
                    AlternateText = x.PictureModel.AlternateText,
                    Title = x.PictureModel.Title,
                    ImageUrl = x.PictureModel.ImageUrl
                }
            }).ToList();
            
            return model;
        }


        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <returns>List of category (simple) models</returns>
        public List<CategorySimpleMobModel> PrepareCategorySimpleModels()
        {
            var models = _catalogModelFactory.PrepareCategorySimpleModels().Select(x => new CategorySimpleMobModel()
            {
                Id = x.Id,
                Name = x.Name,
                HaveSubCategories = x.HaveSubCategories,
                IncludeInTopMenu = x.IncludeInTopMenu,
                NumberOfProducts = x.NumberOfProducts,
                SubCategories = GetSubCategories(x)
            }).ToList();

            return models;

        }

        #endregion

        #region Helper Methods

        private List<CategorySimpleMobModel> GetSubCategories(CategorySimpleModel model)
        {
            var list = new List<CategorySimpleMobModel>();

            if (model.SubCategories != null && model.SubCategories.Any())
            {
                foreach(var subCategory in model.SubCategories)
                {
                    var mobModel = new CategorySimpleMobModel()
                    {
                        Id = subCategory.Id,
                        Name = subCategory.Name,
                        HaveSubCategories = subCategory.HaveSubCategories,
                        IncludeInTopMenu = subCategory.IncludeInTopMenu,
                        NumberOfProducts = subCategory.NumberOfProducts,
                        SubCategories = GetSubCategories(subCategory)
                    };

                    list.Add(mobModel);
                }
            }

            return list;
        }
        //private List<CategorySimpleMobModel> GetSubCategories(List<CategoryModel.SubCategoryModel> SubCategories)
        //{
        //    var list = new List<CategorySimpleMobModel>();

        //    if (SubCategories != null && SubCategories.Any())
        //    {
        //        foreach (var subCategory in SubCategories)
        //        {
        //            var mobModel = new CategorySimpleMobModel()
        //            {
        //                Id = subCategory.Id,
        //                Name = subCategory.Name,
        //                HaveSubCategories = subCategory.HaveSubCategories,
        //                IncludeInTopMenu = subCategory.IncludeInTopMenu,
        //                NumberOfProducts = subCategory.NumberOfProducts,
        //                SubCategories = GetSubCategories(subCategory)
        //            };

        //            list.Add(mobModel);
        //        }
        //    }

        //    return list;
        //}

        public CategoryMobModel PrepareCategoryModel(Category category, CatalogPagingFilteringMobModel command)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var model = new CategoryMobModel
            {
                Id = category.Id,
                Name = _localizationService.GetLocalized(category, x => x.Name),
                Description = _localizationService.GetLocalized(category, x => x.Description),
                MetaKeywords = _localizationService.GetLocalized(category, x => x.MetaKeywords),
                MetaDescription = _localizationService.GetLocalized(category, x => x.MetaDescription),
                MetaTitle = _localizationService.GetLocalized(category, x => x.MetaTitle),
                SeName = _urlRecordService.GetSeName(category),
            };

            //sorting
            PrepareSortingOptions(model.PagingFilteringContext, command);
            //view mode
            PrepareViewModes(model.PagingFilteringContext, command);
            //page size
            PreparePageSizeOptions(model.PagingFilteringContext, command,
                category.AllowCustomersToSelectPageSize,
                category.PageSizeOptions,
                category.PageSize);

            //price ranges
            model.PagingFilteringContext.PriceRangeFilter.LoadPriceRangeFilters(category.PriceRanges, _webHelper, _priceFormatter);
            var selectedPriceRange = model.PagingFilteringContext.PriceRangeFilter.GetSelectedPriceRange(_webHelper, category.PriceRanges);
            decimal? minPriceConverted = null;
            decimal? maxPriceConverted = null;
            if (selectedPriceRange != null)
            {
                if (selectedPriceRange.From.HasValue)
                    minPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.From.Value, _workContext.WorkingCurrency);

                if (selectedPriceRange.To.HasValue)
                    maxPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.To.Value, _workContext.WorkingCurrency);
            }

            //category breadcrumb
            if (_catalogSettings.CategoryBreadcrumbEnabled)
            {
                model.DisplayCategoryBreadcrumb = true;

                model.CategoryBreadcrumb = _categoryService.GetCategoryBreadCrumb(category).Select(catBr =>
                    new CategoryMobModel
                    {
                        Id = catBr.Id,
                        Name = _localizationService.GetLocalized(catBr, x => x.Name),
                        SeName = _urlRecordService.GetSeName(catBr)
                    }).ToList();
            }

            var pictureSize = _mediaSettings.CategoryThumbPictureSize;

            //subcategories
            model.SubCategories = _categoryService.GetAllCategoriesByParentCategoryId(category.Id)
                    .Select(curCategory =>
                    {
                        var subCatModel = new CategorySimpleMobModel
                        {
                            Id = curCategory.Id,
                            Name = _localizationService.GetLocalized(curCategory, y => y.Name),
                            SeName = _urlRecordService.GetSeName(curCategory),
                            Description = _localizationService.GetLocalized(curCategory, y => y.Description)
                        };

                        //prepare picture model
                        var categoryPictureCacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.CategoryPictureModelKey, curCategory,
                            pictureSize, true, _workContext.WorkingLanguage, _webHelper.IsCurrentConnectionSecured(),
                            _storeContext.CurrentStore);

                        subCatModel.Picture = _staticCacheManager.Get(categoryPictureCacheKey, () =>
                        {
                            var picture = _pictureService.GetPictureById(curCategory.PictureId);
                            var pictureModel = new PictureMobModel
                            {
                                FullSizeImageUrl = _pictureService.GetPictureUrl(ref picture),
                                ImageUrl = _pictureService.GetPictureUrl(ref picture, pictureSize),
                                Title = string.Format(
                                    _localizationService.GetResource("Media.Category.ImageLinkTitleFormat"),
                                    subCatModel.Name),
                                AlternateText =
                                    string.Format(
                                        _localizationService.GetResource("Media.Category.ImageAlternateTextFormat"),
                                        subCatModel.Name)
                            };

                            return pictureModel;
                        });

                        return subCatModel;
                    }).ToList();

            //featured products
            if (!_catalogSettings.IgnoreFeaturedProducts)
            {
                //We cache a value indicating whether we have featured products
                IPagedList<Product> featuredProducts = null;
                var cacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.CategoryHasFeaturedProductsKey, category,
                    _customerService.GetCustomerRoleIds(_workContext.CurrentCustomer), _storeContext.CurrentStore);
                var hasFeaturedProductsCache = _staticCacheManager.Get(cacheKey, () =>
                {
                    //no value in the cache yet
                    //let's load products and cache the result (true/false)
                    featuredProducts = _productService.SearchProducts(
                       categoryIds: new List<int> { category.Id },
                       storeId: _storeContext.CurrentStore.Id,
                       visibleIndividuallyOnly: true,
                       featuredProducts: true);

                    return featuredProducts.TotalCount > 0;
                });

                if (hasFeaturedProductsCache && featuredProducts == null)
                {
                    //cache indicates that the category has featured products
                    //let's load them
                    featuredProducts = _productService.SearchProducts(
                       categoryIds: new List<int> { category.Id },
                       storeId: _storeContext.CurrentStore.Id,
                       visibleIndividuallyOnly: true,
                       featuredProducts: true);
                }

                if (featuredProducts != null)
                {
                    model.FeaturedProducts = _productModelFactory.PrepareProductOverviewModels(featuredProducts).ToList();
                }
            }

            var categoryIds = new List<int> { category.Id };

            //include subcategories
            if (_catalogSettings.ShowProductsFromSubcategories)
                categoryIds.AddRange(model.SubCategories.Select(sc => sc.Id));

            //products
            IList<int> alreadyFilteredSpecOptionIds = model.PagingFilteringContext.SpecificationFilter.GetAlreadyFilteredSpecOptionIds(_webHelper);
            var products = _productService.SearchProducts(out var filterableSpecificationAttributeOptionIds,
                true,
                categoryIds: categoryIds,
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                featuredProducts: _catalogSettings.IncludeFeaturedProductsInNormalLists ? null : (bool?)false,
                priceMin: minPriceConverted,
                priceMax: maxPriceConverted,
                filteredSpecs: alreadyFilteredSpecOptionIds,
                orderBy: (ProductSortingEnum)command.OrderBy,
                pageIndex: command.PageNumber - 1,
                pageSize: command.PageSize);
            model.Products = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            model.PagingFilteringContext.LoadPagedList(products);

            //specs
            model.PagingFilteringContext.SpecificationFilter.PrepareSpecsFilters(alreadyFilteredSpecOptionIds,
                filterableSpecificationAttributeOptionIds?.ToArray(), _cacheKeyService,
                _specificationAttributeService, _localizationService, _webHelper, _workContext, _staticCacheManager);

            return model;
        }

        public IList<ProductOverviewMobModel> PrepareProducts(List<int> categoryIds,
            ProductSortingEnum orderBy, IList<int> alreadyFilteredSpecOptionIds,
            int pageNumber = 1, int pageSize = 5, decimal minPriceConverted = 0,
            decimal maxPriceConverted = 1000000)
        {
            var products = _productService.SearchProducts(out var filterableSpecificationAttributeOptionIds,
                true,
                categoryIds: categoryIds,
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                featuredProducts: _catalogSettings.IncludeFeaturedProductsInNormalLists ? null : (bool?)false,
                priceMin: minPriceConverted,
                priceMax: maxPriceConverted,
                filteredSpecs: alreadyFilteredSpecOptionIds,
                orderBy: orderBy,
                pageIndex: pageNumber - 1,
                pageSize: pageSize);
            var productOverviews = _productModelFactory.PrepareProductOverviewModels(products).ToList();
            return productOverviews;
        }
        public IList<CategorySimpleMobModel> PrepareCategories()
        {
            var allCategories = new List<CategorySimpleMobModel>();
            var simpleCategories = new List<CategorySimpleMobModel>();
            var categories = _categoryService.GetAllCategories();
            foreach (var category in categories)
            {
                if(!allCategories.Any(x=> x.Id == category.Id))
                {
                    var _simpleCategories = GetChildCategories(categories.ToList(), category.Id).ToList();
                    allCategories.AddRange(_simpleCategories);
                    var picture = _pictureService.GetPictureById(category.PictureId);
                    simpleCategories.Add(new CategorySimpleMobModel()
                    {
                        Id = category.Id,
                        Description = category.Description,
                        Picture = new PictureMobModel()
                        {
                            FullSizeImageUrl = _pictureService.GetPictureUrl(ref picture),
                            ImageUrl = _pictureService.GetPictureUrl(ref picture, 400)
                        },
                        Name = category.Name,
                        SubCategories = _simpleCategories
                    });
                }
            }
            return simpleCategories;
        }
        private IList<CategorySimpleMobModel> GetChildCategories(List<Category> categories, int categoryId)
        {
            var childCategories = new List<CategorySimpleMobModel>();
            var childCategoriesIds = _categoryService.GetChildCategoryIds(categoryId);
            foreach (var id in childCategoriesIds)
            {
                var _category = categories.Where(x => x.Id == id).FirstOrDefault();
                var picture = _pictureService.GetPictureById(_category.PictureId);
                childCategories.Add(new CategorySimpleMobModel()
                {
                    Id = _category.Id,
                    Description = _category.Description,
                    Picture =  new PictureMobModel()
                        {
                            FullSizeImageUrl = _pictureService.GetPictureUrl(ref picture),
                            ImageUrl = _pictureService.GetPictureUrl(ref picture, 400)
                        },
                    Name = _category.Name,
                    SubCategories = GetChildCategories(categories, _category.Id).ToList()
            });
            }
            return childCategories;
        }
        public string PrepareCategoryTemplateViewPath(int templateId)
        {
            var template = _categoryTemplateService.GetCategoryTemplateById(templateId) ??
                           _categoryTemplateService.GetAllCategoryTemplates().FirstOrDefault();

            if (template == null)
                throw new Exception("No default template could be loaded");

            return template.ViewPath;
        }

        public CategoryNavigationMobModel PrepareCategoryNavigationModel(int currentCategoryId, int currentProductId)
        {
            //get active category
            var activeCategoryId = 0;
            if (currentCategoryId > 0)
            {
                //category details page
                activeCategoryId = currentCategoryId;
            }
            else if (currentProductId > 0)
            {
                //product details page
                var productCategories = _categoryService.GetProductCategoriesByProductId(currentProductId);
                if (productCategories.Any())
                    activeCategoryId = productCategories[0].CategoryId;
            }

            var cachedCategoriesModel = PrepareCategorySimpleModels();
            var model = new CategoryNavigationMobModel
            {
                CurrentCategoryId = activeCategoryId,
                Categories = cachedCategoriesModel
            };

            return model;
        }

        public TopMenuMobModel PrepareTopMenuModel()
        {
            var cachedCategoriesModel = new List<CategorySimpleMobModel>();
            //categories
            if (!_catalogSettings.UseAjaxLoadMenu)
                cachedCategoriesModel = PrepareCategorySimpleModels();

            //top menu topics
            var topicModel = _topicService.GetAllTopics(_storeContext.CurrentStore.Id, onlyIncludedInTopMenu: true)
                    .Select(t => new TopMenuMobModel.TopicMobModel
                    {
                        Id = t.Id,
                        Name = _localizationService.GetLocalized(t, x => x.Title),
                        SeName = _urlRecordService.GetSeName(t)
                    }).ToList();

            var model = new TopMenuMobModel
            {
                Categories = cachedCategoriesModel,
                Topics = topicModel,
                NewProductsEnabled = _catalogSettings.NewProductsEnabled,
                BlogEnabled = _blogSettings.Enabled,
                ForumEnabled = _forumSettings.ForumsEnabled,
                DisplayHomepageMenuItem = _displayDefaultMenuItemSettings.DisplayHomepageMenuItem,
                DisplayNewProductsMenuItem = _displayDefaultMenuItemSettings.DisplayNewProductsMenuItem,
                DisplayProductSearchMenuItem = _displayDefaultMenuItemSettings.DisplayProductSearchMenuItem,
                DisplayCustomerInfoMenuItem = _displayDefaultMenuItemSettings.DisplayCustomerInfoMenuItem,
                DisplayBlogMenuItem = _displayDefaultMenuItemSettings.DisplayBlogMenuItem,
                DisplayForumsMenuItem = _displayDefaultMenuItemSettings.DisplayForumsMenuItem,
                DisplayContactUsMenuItem = _displayDefaultMenuItemSettings.DisplayContactUsMenuItem,
                UseAjaxMenu = _catalogSettings.UseAjaxLoadMenu
            };

            return model;
        }

        public List<CategorySimpleMobModel> PrepareCategorySimpleModels(int rootCategoryId, bool loadSubCategories = true)
        {
            //load and cache them
            var cacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.CategoryAllModelKey,
                _workContext.WorkingLanguage,
                _customerService.GetCustomerRoleIds(_workContext.CurrentCustomer),
                _storeContext.CurrentStore);

            return _staticCacheManager.Get(cacheKey, () => PrepareCategorySimpleModels(0));
        }

        public XDocument PrepareCategoryXmlDocument()
        {
            var cacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.CategoryXmlAllModelKey,
                _workContext.WorkingLanguage,
                _customerService.GetCustomerRoleIds(_workContext.CurrentCustomer),
                _storeContext.CurrentStore);

            return _staticCacheManager.Get(cacheKey, () =>
            {
                var categories = PrepareCategorySimpleModels();

                var xsSubmit = new XmlSerializer(typeof(List<CategorySimpleMobModel>));

                using var strWriter = new StringWriter();
                using var writer = XmlWriter.Create(strWriter);
                xsSubmit.Serialize(writer, categories);
                var xml = strWriter.ToString();

                return XDocument.Parse(xml);
            });
        }

        public List<CategorySimpleMobModel> PrepareRootCategories()
        {
            var doc = PrepareCategoryXmlDocument();

            var models = from xe in doc.Root.XPathSelectElements("CategorySimpleModel")
                         select GetCategorySimpleModel(xe);

            return models.ToList();
        }

        public List<CategorySimpleMobModel> PrepareSubCategories(int id)
        {
            var doc = PrepareCategoryXmlDocument();

            var model = from xe in doc.Descendants("CategorySimpleMobModel")
                        where xe.XPathSelectElement("Id").Value == id.ToString()
                        select xe;

            var models = from xe in model.First().XPathSelectElements("SubCategories/CategorySimpleMobModel")
                         select GetCategorySimpleModel(xe);

            return models.ToList();
        }
        #endregion
        #region Manufacturers

        /// <summary>
        /// Prepare manufacturer model
        /// </summary>
        /// <param name="manufacturer">Manufacturer identifier</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Manufacturer model</returns>
        public ManufacturerMobModel PrepareManufacturerModel(Manufacturer manufacturer, CatalogPagingFilteringMobModel command)
        {
            if (manufacturer == null)
                throw new ArgumentNullException(nameof(manufacturer));

            var model = new ManufacturerMobModel
            {
                Id = manufacturer.Id,
                Name = _localizationService.GetLocalized(manufacturer, x => x.Name),
                Description = _localizationService.GetLocalized(manufacturer, x => x.Description),
                MetaKeywords = _localizationService.GetLocalized(manufacturer, x => x.MetaKeywords),
                MetaDescription = _localizationService.GetLocalized(manufacturer, x => x.MetaDescription),
                MetaTitle = _localizationService.GetLocalized(manufacturer, x => x.MetaTitle),
                SeName = _urlRecordService.GetSeName(manufacturer),
            };

            //sorting
            PrepareSortingOptions(model.PagingFilteringContext, command);
            //view mode
            PrepareViewModes(model.PagingFilteringContext, command);
            //page size
            PreparePageSizeOptions(model.PagingFilteringContext, command,
                manufacturer.AllowCustomersToSelectPageSize,
                manufacturer.PageSizeOptions,
                manufacturer.PageSize);

            //price ranges
            model.PagingFilteringContext.PriceRangeFilter.LoadPriceRangeFilters(manufacturer.PriceRanges, _webHelper, _priceFormatter);
            var selectedPriceRange = model.PagingFilteringContext.PriceRangeFilter.GetSelectedPriceRange(_webHelper, manufacturer.PriceRanges);
            decimal? minPriceConverted = null;
            decimal? maxPriceConverted = null;
            if (selectedPriceRange != null)
            {
                if (selectedPriceRange.From.HasValue)
                    minPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.From.Value, _workContext.WorkingCurrency);

                if (selectedPriceRange.To.HasValue)
                    maxPriceConverted = _currencyService.ConvertToPrimaryStoreCurrency(selectedPriceRange.To.Value, _workContext.WorkingCurrency);
            }

            //featured products
            if (!_catalogSettings.IgnoreFeaturedProducts)
            {
                IPagedList<Product> featuredProducts = null;

                //We cache a value indicating whether we have featured products
                var cacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.ManufacturerHasFeaturedProductsKey,
                    manufacturer,
                    _customerService.GetCustomerRoleIds(_workContext.CurrentCustomer),
                    _storeContext.CurrentStore);
                var hasFeaturedProductsCache = _staticCacheManager.Get(cacheKey, () =>
                {
                    //no value in the cache yet
                    //let's load products and cache the result (true/false)
                    featuredProducts = _productService.SearchProducts(
                       manufacturerId: manufacturer.Id,
                       storeId: _storeContext.CurrentStore.Id,
                       visibleIndividuallyOnly: true,
                       featuredProducts: true);

                    return featuredProducts.TotalCount > 0;
                });

                if (hasFeaturedProductsCache && featuredProducts == null)
                {
                    //cache indicates that the manufacturer has featured products
                    //let's load them
                    featuredProducts = _productService.SearchProducts(
                       manufacturerId: manufacturer.Id,
                       storeId: _storeContext.CurrentStore.Id,
                       visibleIndividuallyOnly: true,
                       featuredProducts: true);
                }

                if (featuredProducts != null)
                {
                    model.FeaturedProducts = _productModelFactory.PrepareProductOverviewModels(featuredProducts).ToList();
                }
            }

            //products
            var products = _productService.SearchProducts(out _, true,
                manufacturerId: manufacturer.Id,
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                featuredProducts: _catalogSettings.IncludeFeaturedProductsInNormalLists ? null : (bool?)false,
                priceMin: minPriceConverted,
                priceMax: maxPriceConverted,
                orderBy: (ProductSortingEnum)command.OrderBy,
                pageIndex: command.PageNumber - 1,
                pageSize: command.PageSize);
            model.Products = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            model.PagingFilteringContext.LoadPagedList(products);

            return model;
        }
        /// <summary>
        /// Prepare manufacturer template view path
        /// </summary>
        /// <param name="templateId">Template identifier</param>
        /// <returns>Manufacturer template view path</returns>
        public string PrepareManufacturerTemplateViewPath(int templateId)
        {
            var template = _manufacturerTemplateService.GetManufacturerTemplateById(templateId) ??
                           _manufacturerTemplateService.GetAllManufacturerTemplates().FirstOrDefault();

            if (template == null)
                throw new Exception("No default template could be loaded");

            return template.ViewPath;
        }
        /// <summary>
        /// Prepare manufacturer all models
        /// </summary>
        /// <returns>List of manufacturer models</returns>
        public List<ManufacturerMobModel> PrepareManufacturerAllModels()
        {
            var model = new List<ManufacturerMobModel>();
            var manufacturers = _manufacturerService.GetAllManufacturers(storeId: _storeContext.CurrentStore.Id);
            foreach (var manufacturer in manufacturers)
            {
                var modelMan = new ManufacturerMobModel
                {
                    Id = manufacturer.Id,
                    Name = _localizationService.GetLocalized(manufacturer, x => x.Name),
                    Description = _localizationService.GetLocalized(manufacturer, x => x.Description),
                    MetaKeywords = _localizationService.GetLocalized(manufacturer, x => x.MetaKeywords),
                    MetaDescription = _localizationService.GetLocalized(manufacturer, x => x.MetaDescription),
                    MetaTitle = _localizationService.GetLocalized(manufacturer, x => x.MetaTitle),
                    SeName = _urlRecordService.GetSeName(manufacturer),
                };

                //prepare picture model
                var pictureSize = _mediaSettings.ManufacturerThumbPictureSize;
                var manufacturerPictureCacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.ManufacturerPictureModelKey,
                    manufacturer, pictureSize, true, _workContext.WorkingLanguage,
                    _webHelper.IsCurrentConnectionSecured(), _storeContext.CurrentStore);
                modelMan.PictureModel = _staticCacheManager.Get(manufacturerPictureCacheKey, () =>
                {
                    var picture = _pictureService.GetPictureById(manufacturer.PictureId);
                    var pictureModel = new PictureMobModel
                    {
                        FullSizeImageUrl = _pictureService.GetPictureUrl(ref picture),
                        ImageUrl = _pictureService.GetPictureUrl(ref picture, pictureSize),
                        Title = string.Format(_localizationService.GetResource("Media.Manufacturer.ImageLinkTitleFormat"), modelMan.Name),
                        AlternateText = string.Format(_localizationService.GetResource("Media.Manufacturer.ImageAlternateTextFormat"), modelMan.Name)
                    };

                    return pictureModel;
                });

                model.Add(modelMan);
            }

            return model;
        }
        /// <summary>
        /// Prepare manufacturer navigation model
        /// </summary>
        /// <param name="currentManufacturerId">Current manufacturer identifier</param>
        /// <returns>Manufacturer navigation model</returns>
        public ManufacturerNavigationMobModel PrepareManufacturerNavigationModel(int currentManufacturerId,int pageSize)
        {
            var cacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.ManufacturerNavigationModelKey,
                currentManufacturerId,
                _workContext.WorkingLanguage,
                _customerService.GetCustomerRoleIds(_workContext.CurrentCustomer),
                _storeContext.CurrentStore);
            if(_catalogSettings.ManufacturersBlockItemsToDisplay == pageSize)
            {
                var cachedModel = _staticCacheManager.Get(cacheKey, () =>
                {
                    var currentManufacturer = _manufacturerService.GetManufacturerById(currentManufacturerId);

                    var manufacturers = _manufacturerService.GetAllManufacturers(storeId: _storeContext.CurrentStore.Id,
                        pageSize: pageSize);
                    var model = new ManufacturerNavigationMobModel
                    {
                        TotalManufacturers = manufacturers.TotalCount
                    };

                    foreach (var manufacturer in manufacturers)
                    {
                        var modelMan = new ManufacturerBriefInfoMobModel
                        {
                            Id = manufacturer.Id,
                            Name = _localizationService.GetLocalized(manufacturer, x => x.Name),
                            SeName = _urlRecordService.GetSeName(manufacturer),
                            IsActive = currentManufacturer != null && currentManufacturer.Id == manufacturer.Id,
                        };
                        model.Manufacturers.Add(modelMan);
                    }

                    return model;
                });

                return cachedModel;
            }
            else
            {
                var currentManufacturer = _manufacturerService.GetManufacturerById(currentManufacturerId);

                    var manufacturers = _manufacturerService.GetAllManufacturers(storeId: _storeContext.CurrentStore.Id,
                        pageSize: pageSize);
                    var model = new ManufacturerNavigationMobModel
                    {
                        TotalManufacturers = manufacturers.TotalCount
                    };

                    foreach (var manufacturer in manufacturers)
                    {
                        var modelMan = new ManufacturerBriefInfoMobModel
                        {
                            Id = manufacturer.Id,
                            Name = _localizationService.GetLocalized(manufacturer, x => x.Name),
                            SeName = _urlRecordService.GetSeName(manufacturer),
                            IsActive = currentManufacturer != null && currentManufacturer.Id == manufacturer.Id,
                        };
                        model.Manufacturers.Add(modelMan);
                    }

                    return model;
            }
        }
        #endregion

        #region Vendors

        /// <summary>
        /// Prepare vendor model
        /// </summary>
        /// <param name="vendor">Vendor</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Vendor model</returns>
        public VendorMobModel PrepareVendorModel(Vendor vendor, CatalogPagingFilteringMobModel command)
        {
            if (vendor == null)
                throw new ArgumentNullException(nameof(vendor));

            var model = new VendorMobModel
            {
                Id = vendor.Id,
                Name = _localizationService.GetLocalized(vendor, x => x.Name),
                Description = _localizationService.GetLocalized(vendor, x => x.Description),
                MetaKeywords = _localizationService.GetLocalized(vendor, x => x.MetaKeywords),
                MetaDescription = _localizationService.GetLocalized(vendor, x => x.MetaDescription),
                MetaTitle = _localizationService.GetLocalized(vendor, x => x.MetaTitle),
                SeName = _urlRecordService.GetSeName(vendor),
                AllowCustomersToContactVendors = _vendorSettings.AllowCustomersToContactVendors
            };

            //sorting
            PrepareSortingOptions(model.PagingFilteringContext, command);
            //view mode
            PrepareViewModes(model.PagingFilteringContext, command);
            //page size
            PreparePageSizeOptions(model.PagingFilteringContext, command,
                vendor.AllowCustomersToSelectPageSize,
                vendor.PageSizeOptions,
                vendor.PageSize);

            //products
            var products = _productService.SearchProducts(out _,
                true,
                vendorId: vendor.Id,
                storeId: _storeContext.CurrentStore.Id,
                visibleIndividuallyOnly: true,
                orderBy: (ProductSortingEnum)command.OrderBy,
                pageIndex: command.PageNumber - 1,
                pageSize: command.PageSize);
            model.Products = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            model.PagingFilteringContext.LoadPagedList(products);

            return model;
        }

        /// <summary>
        /// Prepare vendor all models
        /// </summary>
        /// <returns>List of vendor models</returns>
        public List<VendorMobModel> PrepareVendorAllModels()
        {
            var model = new List<VendorMobModel>();
            var vendors = _vendorService.GetAllVendors();
            foreach (var vendor in vendors)
            {
                var vendorModel = new VendorMobModel
                {
                    Id = vendor.Id,
                    Name = _localizationService.GetLocalized(vendor, x => x.Name),
                    Description = _localizationService.GetLocalized(vendor, x => x.Description),
                    MetaKeywords = _localizationService.GetLocalized(vendor, x => x.MetaKeywords),
                    MetaDescription = _localizationService.GetLocalized(vendor, x => x.MetaDescription),
                    MetaTitle = _localizationService.GetLocalized(vendor, x => x.MetaTitle),
                    SeName = _urlRecordService.GetSeName(vendor),
                    AllowCustomersToContactVendors = _vendorSettings.AllowCustomersToContactVendors
                };

                //prepare picture model
                var pictureSize = _mediaSettings.VendorThumbPictureSize;
                var pictureCacheKey = _cacheKeyService.PrepareKeyForDefaultCache(NopModelCacheDefaults.VendorPictureModelKey,
                    vendor, pictureSize, true, _workContext.WorkingLanguage, _webHelper.IsCurrentConnectionSecured(), _storeContext.CurrentStore);
                vendorModel.PictureModel = _staticCacheManager.Get(pictureCacheKey, () =>
                {
                    var picture = _pictureService.GetPictureById(vendor.PictureId);
                    var pictureModel = new PictureMobModel
                    {
                        FullSizeImageUrl = _pictureService.GetPictureUrl(ref picture),
                        ImageUrl = _pictureService.GetPictureUrl(ref picture, pictureSize),
                        Title = string.Format(_localizationService.GetResource("Media.Vendor.ImageLinkTitleFormat"), vendorModel.Name),
                        AlternateText = string.Format(_localizationService.GetResource("Media.Vendor.ImageAlternateTextFormat"), vendorModel.Name)
                    };

                    return pictureModel;
                });

                model.Add(vendorModel);
            }

            return model;
        }
        /// <summary>
        /// Prepare vendor navigation model
        /// </summary>
        /// <returns>Vendor navigation model</returns>
        public VendorNavigationMobModel PrepareVendorNavigationModel(int pageSize)
        {
            var cacheKey = NopModelCacheDefaults.VendorNavigationModelKey;
            var cachedModel = _staticCacheManager.Get(cacheKey, () =>
            {
                var vendors = _vendorService.GetAllVendors(pageSize: pageSize);
                var model = new VendorNavigationMobModel
                {
                    TotalVendors = vendors.TotalCount
                };

                foreach (var vendor in vendors)
                {
                    model.Vendors.Add(new VendorBriefInfoMobModel
                    {
                        Id = vendor.Id,
                        Name = _localizationService.GetLocalized(vendor, x => x.Name),
                        SeName = _urlRecordService.GetSeName(vendor),
                    });
                }

                return model;
            });

            return cachedModel;
        }
        #endregion

        #region Product tags

        /// <summary>
        /// Prepare popular product tags model
        /// </summary>
        /// <returns>Product tags model</returns>
        public PopularProductTagsMobModel PreparePopularProductTagsModel()
        {
            var model = new PopularProductTagsMobModel();

            //get all tags
            var tags = _productTagService
                .GetAllProductTags()
                //filter by current store
                .Where(x => _productTagService.GetProductCount(x.Id, _storeContext.CurrentStore.Id) > 0)
                .ToList();

            model.TotalTags = tags.Count;

            model.Tags.AddRange(tags
                //order by product count
                .OrderByDescending(x => _productTagService.GetProductCount(x.Id, _storeContext.CurrentStore.Id))
                .Take(_catalogSettings.NumberOfProductTags)
                //sorting
                .OrderBy(x => _localizationService.GetLocalized(x, y => y.Name))
                .Select(tag => new ProductTagMobModel
                {
                    Id = tag.Id,
                    Name = _localizationService.GetLocalized(tag, y => y.Name),
                    SeName = _urlRecordService.GetSeName(tag),
                    ProductCount = _productTagService.GetProductCount(tag.Id, _storeContext.CurrentStore.Id)
                }));

            return model;
        }
        /// <summary>
        /// Prepare products by tag model
        /// </summary>
        /// <param name="productTag">Product tag</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Products by tag model</returns>
        public ProductsByTagMobModel PrepareProductsByTagModel(ProductTag productTag, CatalogPagingFilteringMobModel command)
        {
            if (productTag == null)
                throw new ArgumentNullException(nameof(productTag));

            var model = new ProductsByTagMobModel
            {
                Id = productTag.Id,
                TagName = _localizationService.GetLocalized(productTag, y => y.Name),
                TagSeName = _urlRecordService.GetSeName(productTag)
            };

            //sorting
            PrepareSortingOptions(model.PagingFilteringContext, command);
            //view mode
            PrepareViewModes(model.PagingFilteringContext, command);
            //page size
            PreparePageSizeOptions(model.PagingFilteringContext, command,
                _catalogSettings.ProductsByTagAllowCustomersToSelectPageSize,
                _catalogSettings.ProductsByTagPageSizeOptions,
                _catalogSettings.ProductsByTagPageSize);

            //products
            var products = _productService.SearchProducts(
                storeId: _storeContext.CurrentStore.Id,
                productTagId: productTag.Id,
                visibleIndividuallyOnly: true,
                orderBy: (ProductSortingEnum)command.OrderBy,
                pageIndex: command.PageNumber - 1,
                pageSize: command.PageSize);
            model.Products = _productModelFactory.PrepareProductOverviewModels(products).ToList();

            model.PagingFilteringContext.LoadPagedList(products);
            return model;
        }

        /// <summary>
        /// Prepare product tags all model
        /// </summary>
        /// <returns>Popular product tags model</returns>
        public PopularProductTagsMobModel PrepareProductTagsAllModel()
        {
            var model = new PopularProductTagsMobModel
            {
                Tags = _productTagService
                .GetAllProductTags()
                //filter by current store
                .Where(x => _productTagService.GetProductCount(x.Id, _storeContext.CurrentStore.Id) > 0)
                //sort by name
                .OrderBy(x => _localizationService.GetLocalized(x, y => y.Name))
                .Select(x =>
                {
                    var ptModel = new ProductTagMobModel
                    {
                        Id = x.Id,
                        Name = _localizationService.GetLocalized(x, y => y.Name),
                        SeName = _urlRecordService.GetSeName(x),
                        ProductCount = _productTagService.GetProductCount(x.Id, _storeContext.CurrentStore.Id)
                    };
                    return ptModel;
                })
                .ToList()
            };
            return model;
        }

        #endregion

        #region Searching

        /// <summary>
        /// Prepare search model
        /// </summary>
        /// <param name="model">Search model</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Search model</returns>
        public SearchMobModel PrepareSearchModel(SearchMobModel model, CatalogPagingFilteringMobModel command)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var searchTerms = model.q ?? string.Empty;

            searchTerms = searchTerms.Trim();

            //sorting
            PrepareSortingOptions(model.PagingFilteringContext, command);
            //view mode
            PrepareViewModes(model.PagingFilteringContext, command);
            //page size
            PreparePageSizeOptions(model.PagingFilteringContext, command,
                _catalogSettings.SearchPageAllowCustomersToSelectPageSize,
                _catalogSettings.SearchPagePageSizeOptions,
                _catalogSettings.SearchPageProductsPerPage);


            var categoriesModels = new List<SearchMobModel.CategoryMobModel>();
            //all categories
            var allCategories = _categoryService.GetAllCategories(storeId: _storeContext.CurrentStore.Id);
            foreach (var c in allCategories)
            {
                //generate full category name (breadcrumb)
                var categoryBreadcrumb = string.Empty;
                var breadcrumb = _categoryService.GetCategoryBreadCrumb(c, allCategories);
                for (var i = 0; i <= breadcrumb.Count - 1; i++)
                {
                    categoryBreadcrumb += _localizationService.GetLocalized(breadcrumb[i], x => x.Name);
                    if (i != breadcrumb.Count - 1)
                        categoryBreadcrumb += " >> ";
                }

                categoriesModels.Add(new SearchMobModel.CategoryMobModel
                {
                    Id = c.Id,
                    Breadcrumb = categoryBreadcrumb
                });
            }

            if (categoriesModels.Any())
            {
                //first empty entry
                model.AvailableCategories.Add(new SelectListItem
                {
                    Value = "0",
                    Text = _localizationService.GetResource("Common.All")
                });
                //all other categories
                foreach (var c in categoriesModels)
                {
                    model.AvailableCategories.Add(new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Breadcrumb,
                        Selected = model.cid == c.Id
                    });
                }
            }

            var manufacturers = _manufacturerService.GetAllManufacturers(storeId: _storeContext.CurrentStore.Id);
            if (manufacturers.Any())
            {
                model.AvailableManufacturers.Add(new SelectListItem
                {
                    Value = "0",
                    Text = _localizationService.GetResource("Common.All")
                });
                foreach (var m in manufacturers)
                    model.AvailableManufacturers.Add(new SelectListItem
                    {
                        Value = m.Id.ToString(),
                        Text = _localizationService.GetLocalized(m, x => x.Name),
                        Selected = model.mid == m.Id
                    });
            }

            model.asv = _vendorSettings.AllowSearchByVendor;
            if (model.asv)
            {
                var vendors = _vendorService.GetAllVendors();
                if (vendors.Any())
                {
                    model.AvailableVendors.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = _localizationService.GetResource("Common.All")
                    });
                    foreach (var vendor in vendors)
                        model.AvailableVendors.Add(new SelectListItem
                        {
                            Value = vendor.Id.ToString(),
                            Text = _localizationService.GetLocalized(vendor, x => x.Name),
                            Selected = model.vid == vendor.Id
                        });
                }
            }

            IPagedList<Product> products = new PagedList<Product>(new List<Product>(), 0, 1);
            // only search if query string search keyword is set (used to avoid searching or displaying search term min length error message on /search page load)
            //we don't use "!string.IsNullOrEmpty(searchTerms)" in cases of "ProductSearchTermMinimumLength" set to 0 but searching by other parameters (e.g. category or price filter)
            var isSearchTermSpecified = _httpContextAccessor.HttpContext.Request.Query.ContainsKey("q");
            if (isSearchTermSpecified)
            {
                if (searchTerms.Length < _catalogSettings.ProductSearchTermMinimumLength)
                {
                    model.Warning =
                        string.Format(_localizationService.GetResource("Search.SearchTermMinimumLengthIsNCharacters"),
                            _catalogSettings.ProductSearchTermMinimumLength);
                }
                else
                {
                    var categoryIds = new List<int>();
                    var manufacturerId = 0;
                    decimal? minPriceConverted = null;
                    decimal? maxPriceConverted = null;
                    var searchInDescriptions = false;
                    var vendorId = 0;
                    if (model.adv)
                    {
                        //advanced search
                        var categoryId = model.cid;
                        if (categoryId > 0)
                        {
                            categoryIds.Add(categoryId);
                            if (model.isc)
                            {
                                //include subcategories
                                categoryIds.AddRange(
                                    _categoryService.GetChildCategoryIds(categoryId, _storeContext.CurrentStore.Id));
                            }
                        }

                        manufacturerId = model.mid;

                        //min price
                        if (!string.IsNullOrEmpty(model.pf))
                        {
                            if (decimal.TryParse(model.pf, out var minPrice))
                                minPriceConverted =
                                    _currencyService.ConvertToPrimaryStoreCurrency(minPrice,
                                        _workContext.WorkingCurrency);
                        }

                        //max price
                        if (!string.IsNullOrEmpty(model.pt))
                        {
                            if (decimal.TryParse(model.pt, out var maxPrice))
                                maxPriceConverted =
                                    _currencyService.ConvertToPrimaryStoreCurrency(maxPrice,
                                        _workContext.WorkingCurrency);
                        }

                        if (model.asv)
                            vendorId = model.vid;

                        searchInDescriptions = model.sid;
                    }

                    //var searchInProductTags = false;
                    var searchInProductTags = searchInDescriptions;

                    //products
                    products = _productService.SearchProducts(
                        categoryIds: categoryIds,
                        manufacturerId: manufacturerId,
                        storeId: _storeContext.CurrentStore.Id,
                        visibleIndividuallyOnly: true,
                        priceMin: minPriceConverted,
                        priceMax: maxPriceConverted,
                        keywords: searchTerms,
                        searchDescriptions: searchInDescriptions,
                        searchProductTags: searchInProductTags,
                        languageId: _workContext.WorkingLanguage.Id,
                        orderBy: (ProductSortingEnum)command.OrderBy,
                        pageIndex: command.PageNumber - 1,
                        pageSize: command.PageSize,
                        vendorId: vendorId);
                    model.Products = _productModelFactory.PrepareProductOverviewModels(products).ToList();

                    model.NoResults = !model.Products.Any();

                    //search term statistics
                    if (!string.IsNullOrEmpty(searchTerms))
                    {
                        var searchTerm =
                            _searchTermService.GetSearchTermByKeyword(searchTerms, _storeContext.CurrentStore.Id);
                        if (searchTerm != null)
                        {
                            searchTerm.Count++;
                            _searchTermService.UpdateSearchTerm(searchTerm);
                        }
                        else
                        {
                            searchTerm = new SearchTerm
                            {
                                Keyword = searchTerms,
                                StoreId = _storeContext.CurrentStore.Id,
                                Count = 1
                            };
                            _searchTermService.InsertSearchTerm(searchTerm);
                        }
                    }

                    //event
                    _eventPublisher.Publish(new ProductSearchEvent
                    {
                        SearchTerm = searchTerms,
                        SearchInDescriptions = searchInDescriptions,
                        CategoryIds = categoryIds,
                        ManufacturerId = manufacturerId,
                        WorkingLanguageId = _workContext.WorkingLanguage.Id,
                        VendorId = vendorId
                    });
                }
            }

            model.PagingFilteringContext.LoadPagedList(products);
            return model;
        }

        /// <summary>
        /// Prepare search box model
        /// </summary>
        /// <returns>Search box model</returns>
        public SearchBoxMobModel PrepareSearchBoxModel()
        {
            var model = new SearchBoxMobModel
            {
                AutoCompleteEnabled = _catalogSettings.ProductSearchAutoCompleteEnabled,
                ShowProductImagesInSearchAutoComplete = _catalogSettings.ShowProductImagesInSearchAutoComplete,
                SearchTermMinimumLength = _catalogSettings.ProductSearchTermMinimumLength,
                ShowSearchBox = _catalogSettings.ProductSearchEnabled
            };
            return model;
        }

        #endregion
        #region Common

        /// <summary>
        /// Prepare sorting options
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        public IList<SelectListItem> GetSortingOption()
        {
            var availableSortOptions = new List<SelectListItem>();
            //get active sorting options
            var activeSortingOptionsIds = Enum.GetValues(typeof(ProductSortingEnum)).Cast<int>()
                .Except(_catalogSettings.ProductSortingEnumDisabled).ToList();
            if (!activeSortingOptionsIds.Any())
                return availableSortOptions;

            //order sorting options
            var orderedActiveSortingOptions = activeSortingOptionsIds
                .Select(id => new { Id = id, Order = _catalogSettings.ProductSortingEnumDisplayOrder.TryGetValue(id, out var order) ? order : id })
                .OrderBy(option => option.Order).ToList();
            foreach (var option in orderedActiveSortingOptions)
            {
                availableSortOptions.Add(new SelectListItem
                {
                    Text = _localizationService.GetLocalizedEnum((ProductSortingEnum)option.Id),
                    Value =  option.Id.ToString()
                });
            }
            return availableSortOptions;
        }
        public void PrepareSortingOptions(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command)
        {
            if (pagingFilteringModel == null)
                throw new ArgumentNullException(nameof(pagingFilteringModel));

            if (command == null)
                throw new ArgumentNullException(nameof(command));

            //set the order by position by default
            pagingFilteringModel.OrderBy = command.OrderBy;
            command.OrderBy = (int)ProductSortingEnum.Position;

            //ensure that product sorting is enabled
            if (!_catalogSettings.AllowProductSorting)
                return;

            //get active sorting options
            var activeSortingOptionsIds = Enum.GetValues(typeof(ProductSortingEnum)).Cast<int>()
                .Except(_catalogSettings.ProductSortingEnumDisabled).ToList();
            if (!activeSortingOptionsIds.Any())
                return;

            //order sorting options
            var orderedActiveSortingOptions = activeSortingOptionsIds
                .Select(id => new { Id = id, Order = _catalogSettings.ProductSortingEnumDisplayOrder.TryGetValue(id, out var order) ? order : id })
                .OrderBy(option => option.Order).ToList();

            pagingFilteringModel.AllowProductSorting = true;
            command.OrderBy = pagingFilteringModel.OrderBy ?? orderedActiveSortingOptions.FirstOrDefault().Id;

            //prepare available model sorting options
            var currentPageUrl = _webHelper.GetThisPageUrl(true);
            foreach (var option in orderedActiveSortingOptions)
            {
                pagingFilteringModel.AvailableSortOptions.Add(new SelectListItem
                {
                    Text = _localizationService.GetLocalizedEnum((ProductSortingEnum)option.Id),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "orderby", option.Id.ToString()),
                    Selected = option.Id == command.OrderBy
                });
            }
        }
        /// <summary>
        /// Prepare view modes
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        public IList<SelectListItem> GetViewModes()
        {
            var availableViewModes = new List<SelectListItem>();
            //grid, 0 is mean grid
            availableViewModes.Add(new SelectListItem
            {
                Text = _localizationService.GetResource("Catalog.ViewMode.Grid"),
                Value = "0",
            });
            //list
            availableViewModes.Add(new SelectListItem
            {
                Text = _localizationService.GetResource("Catalog.ViewMode.List"),
                Value = "1",
            });
            return availableViewModes;
        }
        public void PrepareViewModes(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command)
        {
            if (pagingFilteringModel == null)
                throw new ArgumentNullException(nameof(pagingFilteringModel));

            if (command == null)
                throw new ArgumentNullException(nameof(command));

            pagingFilteringModel.AllowProductViewModeChanging = _catalogSettings.AllowProductViewModeChanging;

            var viewMode = !string.IsNullOrEmpty(command.ViewMode)
                ? command.ViewMode
                : _catalogSettings.DefaultViewMode;
            pagingFilteringModel.ViewMode = viewMode;
            if (pagingFilteringModel.AllowProductViewModeChanging)
            {
                var currentPageUrl = _webHelper.GetThisPageUrl(true);
                //grid
                pagingFilteringModel.AvailableViewModes.Add(new SelectListItem
                {
                    Text = _localizationService.GetResource("Catalog.ViewMode.Grid"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode", "grid"),
                    Selected = viewMode == "grid"
                });
                //list
                pagingFilteringModel.AvailableViewModes.Add(new SelectListItem
                {
                    Text = _localizationService.GetResource("Catalog.ViewMode.List"),
                    Value = _webHelper.ModifyQueryString(currentPageUrl, "viewmode", "list"),
                    Selected = viewMode == "list"
                });
            }
        }
        /// <summary>
        /// Prepare page size options
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <param name="allowCustomersToSelectPageSize">Are customers allowed to select page size?</param>
        /// <param name="pageSizeOptions">Page size options</param>
        /// <param name="fixedPageSize">Fixed page size</param>
        public void PreparePageSizeOptions(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command, bool allowCustomersToSelectPageSize, string pageSizeOptions, int fixedPageSize)
        {
            if (pagingFilteringModel == null)
                throw new ArgumentNullException(nameof(pagingFilteringModel));

            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (command.PageNumber <= 0)
                command.PageNumber = 1;

            pagingFilteringModel.AllowCustomersToSelectPageSize = false;
            if (allowCustomersToSelectPageSize && pageSizeOptions != null)
            {
                var pageSizes = pageSizeOptions.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (pageSizes.Any())
                {
                    // get the first page size entry to use as the default (category page load) or if customer enters invalid value via query string
                    if (command.PageSize <= 0 || !pageSizes.Contains(command.PageSize.ToString()))
                    {
                        if (int.TryParse(pageSizes.FirstOrDefault(), out var temp))
                        {
                            if (temp > 0)
                            {
                                command.PageSize = temp;
                            }
                        }
                    }

                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.RemoveQueryString(currentPageUrl, "pagenumber");

                    foreach (var pageSize in pageSizes)
                    {
                        if (!int.TryParse(pageSize, out var temp))
                            continue;

                        if (temp <= 0)
                            continue;

                        pagingFilteringModel.PageSizeOptions.Add(new SelectListItem
                        {
                            Text = pageSize,
                            Value = _webHelper.ModifyQueryString(sortUrl, "pagesize", pageSize),
                            Selected = pageSize.Equals(command.PageSize.ToString(), StringComparison.InvariantCultureIgnoreCase)
                        });
                    }

                    if (pagingFilteringModel.PageSizeOptions.Any())
                    {
                        pagingFilteringModel.PageSizeOptions = pagingFilteringModel.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();
                        pagingFilteringModel.AllowCustomersToSelectPageSize = true;

                        if (command.PageSize <= 0)
                        {
                            command.PageSize = int.Parse(pagingFilteringModel.PageSizeOptions.First().Text);
                        }
                    }
                }
            }
            else
            {
                //customer is not allowed to select a page size
                command.PageSize = fixedPageSize;
            }

            //ensure pge size is specified
            if (command.PageSize <= 0)
            {
                command.PageSize = fixedPageSize;
            }
        }
        #endregion

        #region Utilities

        protected virtual CategorySimpleMobModel GetCategorySimpleModel(XElement elem)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            return new CategorySimpleMobModel
            {
                Id = int.Parse(elem.XPathSelectElement("Id").Value),
                Name = elem.XPathSelectElement("Name").Value,
                SeName = elem.XPathSelectElement("SeName").Value,

                NumberOfProducts = !string.IsNullOrEmpty(elem.XPathSelectElement("NumberOfProducts").Value)
                    ? int.Parse(elem.XPathSelectElement("NumberOfProducts").Value)
                    : (int?)null,

                IncludeInTopMenu = bool.Parse(elem.XPathSelectElement("IncludeInTopMenu").Value),
                HaveSubCategories = bool.Parse(elem.XPathSelectElement("HaveSubCategories").Value)
            };
        }

        #endregion
    }
}
