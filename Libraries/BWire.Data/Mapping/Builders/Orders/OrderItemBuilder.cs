using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Core.Domain.Orders;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a order item entity builder
    /// </summary>
    public partial class OrderItemBuilder : NopEntityBuilder<OrderItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderItem.OrderId)).AsInt32().ForeignKey<Order>()
                .WithColumn(nameof(OrderItem.ProductId)).AsInt32().ForeignKey<Product>();
        }

        #endregion
    }
}