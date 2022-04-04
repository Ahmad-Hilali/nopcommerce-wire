using FluentMigrator;
using BWire.Core.Domain.Orders;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037691")]
    public class AddShoppingCartItemShoppingCartTypeIdCustomerIdIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_ShoppingCartItem_ShoppingCartTypeId_CustomerId").OnTable(nameof(ShoppingCartItem))
                .OnColumn(nameof(ShoppingCartItem.ShoppingCartTypeId)).Ascending()
                .OnColumn(nameof(ShoppingCartItem.CustomerId)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}