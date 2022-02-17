using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.ShoppingCart
{
    public partial class EstimateShippingMobModel : BaseNopModel
    {
        public EstimateShippingMobModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
        }

        public bool Enabled { get; set; }

        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string ZipPostalCode { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
    }

    public partial class EstimateShippingResultMobModel : BaseNopModel
    {
        public EstimateShippingResultMobModel()
        {
            ShippingOptions = new List<ShippingOptionMobModel>();
            Warnings = new List<string>();
        }

        public IList<ShippingOptionMobModel> ShippingOptions { get; set; }

        public IList<string> Warnings { get; set; }

        #region Nested Classes

        public partial class ShippingOptionMobModel : BaseNopModel
        {
            public string Name { get; set; }

            public string ShippingRateComputationMethodSystemName { get; set; }

            public string Description { get; set; }

            public string Price { get; set; }

            public decimal Rate { get; set; }

            public string DeliveryDateFormat { get; set; }

            public bool Selected { get; set; }
        }

        #endregion
    }
}
