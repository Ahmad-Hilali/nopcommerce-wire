using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Vendors;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Mobile.Catalog;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Nop.Web.Factories.Mobile
{
    public partial interface ICatalogMobFactory
    {
        #region Common

        /// <summary>
        /// Prepare sorting options
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        IList<SelectListItem> GetSortingOption();
        IList<SelectListItem> GetViewModes();
        void PrepareSortingOptions(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare view modes
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        void PrepareViewModes(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare page size options
        /// </summary>
        /// <param name="pagingFilteringModel">Catalog paging filtering model</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <param name="allowCustomersToSelectPageSize">Are customers allowed to select page size?</param>
        /// <param name="pageSizeOptions">Page size options</param>
        /// <param name="fixedPageSize">Fixed page size</param>
        void PreparePageSizeOptions(CatalogPagingFilteringMobModel pagingFilteringModel, CatalogPagingFilteringMobModel command,
            bool allowCustomersToSelectPageSize, string pageSizeOptions, int fixedPageSize);

        #endregion
        #region Categories

        /// <summary>
        /// Prepare category model
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Category model</returns>
        CategoryMobModel PrepareCategoryModel(Category category, CatalogPagingFilteringMobModel command);
        /// <summary>
        /// Prepare Products
        /// </summary>
        /// <param name="categoryIds">Category Ids</param>
        /// <param name="orderBy">Sorting option</param>
        /// <param name="alreadyFilteredSpecOptionIds">Filtering option</param>
        /// <param name="pageNumber">Paging option</param>
        /// <param name="pageSize">Paging option</param>
        /// <param name="minPriceConverted">Price filtering option</param>
        /// <param name="maxPriceConverted">Price filtering option</param>
        /// <returns>Category model</returns>
        IList<ProductOverviewMobModel> PrepareProducts(List<int> categoryIds,
            ProductSortingEnum orderBy, IList<int> alreadyFilteredSpecOptionIds,
            int pageNumber = 1, int pageSize = 5, decimal minPriceConverted = 0,
            decimal maxPriceConverted = 1000000);
        IList<CategorySimpleMobModel> PrepareCategories();
        /// <summary>
        /// Prepare category template view path
        /// </summary>
        /// <param name="templateId">Template identifier</param>
        /// <returns>Category template view path</returns>
        string PrepareCategoryTemplateViewPath(int templateId);

        /// <summary>
        /// Prepare category navigation model
        /// </summary>
        /// <param name="currentCategoryId">Current category identifier</param>
        /// <param name="currentProductId">Current product identifier</param>
        /// <returns>Category navigation model</returns>
        CategoryNavigationMobModel PrepareCategoryNavigationModel(int currentCategoryId,
            int currentProductId);

        /// <summary>
        /// Prepare top menu model
        /// </summary>
        /// <returns>Top menu model</returns>
        TopMenuMobModel PrepareTopMenuModel();

        /// <summary>
        /// Prepare homepage category models
        /// </summary>
        /// <returns>List of homepage category models</returns>
        List<CategoryMobModel> PrepareHomepageCategoryModels();

        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <returns>List of category (simple) models</returns>
        List<CategorySimpleMobModel> PrepareCategorySimpleModels();

        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <param name="rootCategoryId">Root category identifier</param>
        /// <param name="loadSubCategories">A value indicating whether subcategories should be loaded</param>
        /// <returns>List of category (simple) models</returns>
        //List<CategorySimpleModel> PrepareCategorySimpleModels(int rootCategoryId, bool loadSubCategories = true);
        List<CategorySimpleMobModel> PrepareCategorySimpleModels(int rootCategoryId, bool loadSubCategories = true);

        /// <summary>
        /// Prepare category (simple) xml document
        /// </summary>
        /// <returns>Xml document of category (simple) models</returns>
        XDocument PrepareCategoryXmlDocument();

        /// <summary>
        /// Prepare root categories for menu
        /// </summary>
        /// <returns>List of category (simple) models</returns>
        List<CategorySimpleMobModel> PrepareRootCategories();

        /// <summary>
        /// Prepare subcategories for menu
        /// </summary>
        /// <param name="id">Id of category to get subcategory</param>
        /// <returns></returns>
        List<CategorySimpleMobModel> PrepareSubCategories(int id);

        #endregion

        #region Manufacturers

        /// <summary>
        /// Prepare manufacturer model
        /// </summary>
        /// <param name="manufacturer">Manufacturer identifier</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Manufacturer model</returns>
        ManufacturerMobModel PrepareManufacturerModel(Manufacturer manufacturer, CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare manufacturer template view path
        /// </summary>
        /// <param name="templateId">Template identifier</param>
        /// <returns>Manufacturer template view path</returns>
        string PrepareManufacturerTemplateViewPath(int templateId);

        /// <summary>
        /// Prepare manufacturer all models
        /// </summary>
        /// <returns>List of manufacturer models</returns>
        List<ManufacturerMobModel> PrepareManufacturerAllModels();

        /// <summary>
        /// Prepare manufacturer navigation model
        /// </summary>
        /// <param name="currentManufacturerId">Current manufacturer identifier</param>
        /// <returns>Manufacturer navigation model</returns>
        ManufacturerNavigationMobModel PrepareManufacturerNavigationModel(int currentManufacturerId,int pageSize);

        #endregion

        #region Vendors

        /// <summary>
        /// Prepare vendor model
        /// </summary>
        /// <param name="vendor">Vendor</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Vendor model</returns>
        VendorMobModel PrepareVendorModel(Vendor vendor, CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare vendor all models
        /// </summary>
        /// <returns>List of vendor models</returns>
        List<VendorMobModel> PrepareVendorAllModels();

        /// <summary>
        /// Prepare vendor navigation model
        /// </summary>
        /// <returns>Vendor navigation model</returns>
        VendorNavigationMobModel PrepareVendorNavigationModel(int pageSize);

        #endregion

        #region Product tags

        /// <summary>
        /// Prepare popular product tags model
        /// </summary>
        /// <returns>Product tags model</returns>
        PopularProductTagsMobModel PreparePopularProductTagsModel();

        /// <summary>
        /// Prepare products by tag model
        /// </summary>
        /// <param name="productTag">Product tag</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Products by tag model</returns>
        ProductsByTagMobModel PrepareProductsByTagModel(ProductTag productTag,
            CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare product tags all model
        /// </summary>
        /// <returns>Popular product tags model</returns>
        PopularProductTagsMobModel PrepareProductTagsAllModel();

        #endregion

        #region Searching

        /// <summary>
        /// Prepare search model
        /// </summary>
        /// <param name="model">Search model</param>
        /// <param name="command">Catalog paging filtering command</param>
        /// <returns>Search model</returns>
        SearchMobModel PrepareSearchModel(SearchMobModel model, CatalogPagingFilteringMobModel command);

        /// <summary>
        /// Prepare search box model
        /// </summary>
        /// <returns>Search box model</returns>
        SearchBoxMobModel PrepareSearchBoxModel();

        #endregion
    }
}
