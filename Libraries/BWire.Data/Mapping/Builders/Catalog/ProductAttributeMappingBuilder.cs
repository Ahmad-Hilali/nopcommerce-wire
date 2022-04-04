using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product attribute mapping entity builder
    /// </summary>
    public partial class ProductAttributeMappingBuilder : NopEntityBuilder<ProductAttributeMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductAttributeMapping.ProductAttributeId)).AsInt32().ForeignKey<ProductAttribute>()
                .WithColumn(nameof(ProductAttributeMapping.ProductId)).AsInt32().ForeignKey<Product>();
        }

        #endregion
    }
}