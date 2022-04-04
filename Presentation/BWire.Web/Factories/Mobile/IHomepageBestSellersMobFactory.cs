using BWire.Web.Models.Catalog;
using System.Collections.Generic;

namespace BWire.Web.Factories.Mobile
{
    public interface IHomepageBestSellersMobFactory
    {
        IEnumerable<ProductOverviewModel> GetHomepageBestSellers(int? productThumbPictureSize);
    }
}
