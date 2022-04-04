using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Shipping;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Shipping
{
    /// <summary>
    /// Represents a shipment item entity builder
    /// </summary>
    public partial class ShipmentItemBuilder : NopEntityBuilder<ShipmentItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(ShipmentItem.ShipmentId)).AsInt32().ForeignKey<Shipment>();
        }

        #endregion
    }
}