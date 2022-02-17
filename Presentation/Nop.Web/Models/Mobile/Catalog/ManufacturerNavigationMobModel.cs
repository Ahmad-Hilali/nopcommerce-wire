using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Catalog
{
    public partial class ManufacturerNavigationMobModel : BaseNopModel
    {
        public ManufacturerNavigationMobModel()
        {
            Manufacturers = new List<ManufacturerBriefInfoMobModel>();
        }

        public IList<ManufacturerBriefInfoMobModel> Manufacturers { get; set; }

        public int TotalManufacturers { get; set; }
    }

    public partial class ManufacturerBriefInfoMobModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public bool IsActive { get; set; }
    }
}
