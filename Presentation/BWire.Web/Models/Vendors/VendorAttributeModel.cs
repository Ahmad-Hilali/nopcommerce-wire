using System.Collections.Generic;
using BWire.Core.Domain.Catalog;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Vendors
{
    public partial class VendorAttributeModel : BaseNopEntityModel
    {
        public VendorAttributeModel()
        {
            Values = new List<VendorAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<VendorAttributeValueModel> Values { get; set; }

    }

    public partial class VendorAttributeValueModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}