using FluentMigrator;
using FluentMigrator.SqlServer;
using BWire.Core.Domain.Catalog;
using BWire.Data.Mapping;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 12:02:35:9280390")]
    public class AddPMMProductIdExtendedIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_PMM_ProductId_Extended").OnTable(NameCompatibilityManager.GetTableName(typeof(ProductManufacturer)))
                .OnColumn(nameof(ProductManufacturer.ProductId)).Ascending()
                .OnColumn(nameof(ProductManufacturer.IsFeaturedProduct)).Ascending()
                .WithOptions().NonClustered()
                .Include(nameof(ProductManufacturer.ManufacturerId));
        }

        #endregion
    }
}