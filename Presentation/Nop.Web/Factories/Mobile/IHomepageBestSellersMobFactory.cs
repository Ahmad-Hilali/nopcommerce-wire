using Nop.Web.Models.Catalog;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public interface IHomepageBestSellersMobFactory
    {
        IEnumerable<ProductOverviewModel> GetHomepageBestSellers(int? productThumbPictureSize);
    }
}
