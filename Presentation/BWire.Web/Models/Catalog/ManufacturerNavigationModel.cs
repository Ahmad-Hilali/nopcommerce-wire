using System.Collections.Generic;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Catalog
{
    public partial class ManufacturerNavigationModel : BaseNopModel
    {
        public ManufacturerNavigationModel()
        {
            Manufacturers = new List<ManufacturerBriefInfoModel>();
        }

        public IList<ManufacturerBriefInfoModel> Manufacturers { get; set; }

        public int TotalManufacturers { get; set; }
    }

    public partial class ManufacturerBriefInfoModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public string SeName { get; set; }
        
        public bool IsActive { get; set; }
    }
}