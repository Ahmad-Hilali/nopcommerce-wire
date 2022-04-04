using FluentMigrator;
using BWire.Core.Domain.Directory;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037708")]
    public class AddCurrencyDisplayOrderIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_Currency_DisplayOrder").OnTable(nameof(Currency))
                .OnColumn(nameof(Currency.DisplayOrder)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}