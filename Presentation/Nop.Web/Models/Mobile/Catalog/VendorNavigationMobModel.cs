using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class VendorNavigationMobModel : BaseNopModel
    {
        public VendorNavigationMobModel()
        {
            Vendors = new List<VendorBriefInfoMobModel>();
        }

        public IList<VendorBriefInfoMobModel> Vendors { get; set; }

        public int TotalVendors { get; set; }
    }

    public partial class VendorBriefInfoMobModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
    }
}

