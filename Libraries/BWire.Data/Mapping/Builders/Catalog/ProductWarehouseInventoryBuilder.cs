using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Core.Domain.Shipping;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product warehouse inventory entity builder
    /// </summary>
    public partial class ProductWarehouseInventoryBuilder : NopEntityBuilder<ProductWarehouseInventory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductWarehouseInventory.ProductId)).AsInt32().ForeignKey<Product>()
                .WithColumn(nameof(ProductWarehouseInventory.WarehouseId)).AsInt32().ForeignKey<Warehouse>();
        }

        #endregion
    }
}