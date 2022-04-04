using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Shipping;

namespace BWire.Data.Mapping.Builders.Shipping
{
    /// <summary>
    /// Represents a shipping method entity builder
    /// </summary>
    public partial class ShippingMethodBuilder : NopEntityBuilder<ShippingMethod>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(ShippingMethod.Name)).AsString(400).NotNullable();
        }

        #endregion
    }
}