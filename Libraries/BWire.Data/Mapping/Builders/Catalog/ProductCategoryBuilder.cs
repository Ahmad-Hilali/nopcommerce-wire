using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product category entity builder
    /// </summary>
    public partial class ProductCategoryBuilder : NopEntityBuilder<ProductCategory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductCategory.CategoryId)).AsInt32().ForeignKey<Category>()
                .WithColumn(nameof(ProductCategory.ProductId)).AsInt32().ForeignKey<Product>();
        }

        #endregion
    }
}