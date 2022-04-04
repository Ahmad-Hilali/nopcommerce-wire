using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Web.Areas.Admin.Models.Common;
using BWire.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Tax.Avalara.Models.Configuration
{
    /// <summary>
    /// Represents a configuration model
    /// </summary>
    public class ConfigurationModel
    {
        #region Ctor

        public ConfigurationModel()
        {
            TestAddress = new AddressModel();
            Companies = new List<SelectListItem>();
            TaxOriginAddressTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public bool IsConfigured { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.AccountId")]
        public string AccountId { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.LicenseKey")]
        [DataType(DataType.Password)]
        [NoTrim]
        public string LicenseKey { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.Company")]
        public string CompanyCode { get; set; }
        public IList<SelectListItem> Companies { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.CommitTransactions")]
        public bool CommitTransactions { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.ValidateAddress")]
        public bool ValidateAddress { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.TaxOriginAddressType")]
        public int TaxOriginAddressTypeId { get; set; }
        public IList<SelectListItem> TaxOriginAddressTypes { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.EnableLogging")]
        public bool EnableLogging { get; set; }

        public AddressModel TestAddress { get; set; }

        public string TestTaxResult { get; set; }


        public bool HideGeneralBlock { get; set; }

        public bool HideLogBlock { get; set; }

        #endregion
    }
}