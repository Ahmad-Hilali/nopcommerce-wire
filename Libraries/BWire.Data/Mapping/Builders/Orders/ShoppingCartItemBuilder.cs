using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Orders;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a shopping cart item entity builder
    /// </summary>
    public partial class ShoppingCartItemBuilder : NopEntityBuilder<ShoppingCartItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ShoppingCartItem.CustomerId)).AsInt32().ForeignKey<Customer>()
                .WithColumn(nameof(ShoppingCartItem.ProductId)).AsInt32().ForeignKey<Product>();
        }

        #endregion
    }
}