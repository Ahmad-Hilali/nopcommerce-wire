using System.Collections.Generic;
using BWire.Core.Domain.Catalog;

namespace BWire.Services.Catalog
{
    /// <summary>
    /// Review type service interface
    /// </summary>
    public partial interface IReviewTypeService
    {
        #region ReviewType

        /// <summary>
        /// Delete the review type
        /// </summary>
        /// <param name="reviewType">Review type</param>
        void DeleteReiewType(ReviewType reviewType);

        /// <summary>
        /// Get all review types
        /// </summary>
        /// <returns>Review types</returns>
        IList<ReviewType> GetAllReviewTypes();

        /// <summary>
        /// Get the review type 
        /// </summary>
        /// <param name="reviewTypeId">Review type identifier</param>
        /// <returns>Review type</returns>
        ReviewType GetReviewTypeById(int reviewTypeId);

        /// <summary>
        /// Insert the review type
        /// </summary>
        /// <param name="reviewType">Review type</param>
        void InsertReviewType(ReviewType reviewType);

        /// <summary>
        /// Update the review type
        /// </summary>
        /// <param name="reviewType">Review type</param>
        void UpdateReviewType(ReviewType reviewType);

        #endregion

        #region ProductReviewReviewTypeMapping

        /// <summary>
        /// Get product review and review type mappings by product review identifier
        /// </summary>
        /// <param name="productReviewId">The product review identifier</param>
        /// <returns>Product review and review type mapping collection</returns>
        IList<ProductReviewReviewTypeMapping> GetProductReviewReviewTypeMappingsByProductReviewId(int productReviewId);

        /// <summary>
        /// Inserts a product review and review type mapping
        /// </summary>
        /// <param name="productReviewReviewType">Product review and review type mapping</param>
        void InsertProductReviewReviewTypeMappings(ProductReviewReviewTypeMapping productReviewReviewType);

        #endregion
    }
}
