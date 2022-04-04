using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Orders;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a order note entity builder
    /// </summary>
    public partial class OrderNoteBuilder : NopEntityBuilder<OrderNote>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(OrderNote.Note)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(OrderNote.OrderId)).AsInt32().ForeignKey<Order>();
        }

        #endregion
    }
}