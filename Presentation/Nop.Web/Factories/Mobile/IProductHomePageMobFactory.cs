using Nop.Core.Domain.Catalog;
using Nop.Web.Models.Catalog;
using System.Collections.Generic;

namespace Nop.Web.Factories.Mobile
{
    public interface IProductHomePageMobFactory
    {
        /// <summary>
        /// Prepare the product overview models
        /// </summary>
        /// <param name="products">Collection of products</param>
        /// <param name="preparePriceModel">Whether to prepare the price model</param>
        /// <param name="preparePictureModel">Whether to prepare the picture model</param>
        /// <param name="productThumbPictureSize">Product thumb picture size (longest side); pass null to use the default value of media settings</param>
        /// <param name="prepareSpecificationAttributes">Whether to prepare the specification attribute models</param>
        /// <param name="forceRedirectionAfterAddingToCart">Whether to force redirection after adding to cart</param>
        /// <returns>Collection of product overview model</returns>
        IEnumerable<ProductOverviewModel> GetHomePageProducts(int? productThumbPictureSize);
    }
}
