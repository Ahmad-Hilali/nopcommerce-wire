using System.Data;
using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Orders;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a recurring payment entity builder
    /// </summary>
    public partial class RecurringPaymentBuilder : NopEntityBuilder<RecurringPayment>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(RecurringPayment.InitialOrderId)).AsInt32().ForeignKey<Order>(onDelete: Rule.None);
        }

        #endregion
    }
}