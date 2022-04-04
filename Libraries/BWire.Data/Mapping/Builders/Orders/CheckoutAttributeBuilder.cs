using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Orders;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a checkout attribute entity builder
    /// </summary>
    public partial class CheckoutAttributeBuilder : NopEntityBuilder<CheckoutAttribute>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(CheckoutAttribute.Name)).AsString(400).NotNullable();
        }

        #endregion
    }
}