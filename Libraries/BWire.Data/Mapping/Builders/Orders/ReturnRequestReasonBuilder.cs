using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Orders;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a return request reason entity builder
    /// </summary>
    public partial class ReturnRequestReasonBuilder : NopEntityBuilder<ReturnRequestReason>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(ReturnRequestReason.Name)).AsString(400).NotNullable();
        }

        #endregion
    }
}