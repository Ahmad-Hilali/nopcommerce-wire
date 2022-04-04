using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Orders;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a recurring payment history entity builder
    /// </summary>
    public partial class RecurringPaymentHistoryBuilder : NopEntityBuilder<RecurringPaymentHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(RecurringPaymentHistory.RecurringPaymentId)).AsInt32().ForeignKey<RecurringPayment>();
        }

        #endregion
    }
}