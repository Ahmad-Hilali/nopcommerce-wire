using FluentMigrator;
using BWire.Core.Domain.Catalog;
using BWire.Data.Mapping;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647938")]
    public class AddProductManufacturerMappingIsFeaturedProductIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_Product_Manufacturer_Mapping_IsFeaturedProduct")
                .OnTable(NameCompatibilityManager.GetTableName(typeof(ProductManufacturer)))
                .OnColumn(nameof(ProductManufacturer.IsFeaturedProduct)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}