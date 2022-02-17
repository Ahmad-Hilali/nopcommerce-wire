using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class SearchMobModel : BaseNopModel
    {
        public SearchMobModel()
        {
            PagingFilteringContext = new CatalogPagingFilteringMobModel();
            Products = new List<ProductOverviewMobModel>();

            AvailableCategories = new List<SelectListItem>();
            AvailableManufacturers = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
        }

        public string Warning { get; set; }

        public bool NoResults { get; set; }

        /// <summary>
        /// Query string
        /// </summary>
        [NopResourceDisplayName("Search.SearchTerm")]
        public string q { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        [NopResourceDisplayName("Search.Category")]
        public int cid { get; set; }

        [NopResourceDisplayName("Search.IncludeSubCategories")]
        public bool isc { get; set; }

        /// <summary>
        /// Manufacturer ID
        /// </summary>
        [NopResourceDisplayName("Search.Manufacturer")]
        public int mid { get; set; }

        /// <summary>
        /// Vendor ID
        /// </summary>
        [NopResourceDisplayName("Search.Vendor")]
        public int vid { get; set; }

        /// <summary>
        /// Price - From 
        /// </summary>
        public string pf { get; set; }

        /// <summary>
        /// Price - To
        /// </summary>
        public string pt { get; set; }

        /// <summary>
        /// A value indicating whether to search in descriptions
        /// </summary>
        [NopResourceDisplayName("Search.SearchInDescriptions")]
        public bool sid { get; set; }

        /// <summary>
        /// A value indicating whether "advanced search" is enabled
        /// </summary>
        [NopResourceDisplayName("Search.AdvancedSearch")]
        public bool adv { get; set; }

        /// <summary>
        /// A value indicating whether "allow search by vendor" is enabled
        /// </summary>
        public bool asv { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }
        public IList<SelectListItem> AvailableManufacturers { get; set; }
        public IList<SelectListItem> AvailableVendors { get; set; }


        public CatalogPagingFilteringMobModel PagingFilteringContext { get; set; }
        public IList<ProductOverviewMobModel> Products { get; set; }

        #region Nested classes

        public class CategoryMobModel : BaseNopEntityModel
        {
            public string Breadcrumb { get; set; }
        }

        #endregion
    }
}
