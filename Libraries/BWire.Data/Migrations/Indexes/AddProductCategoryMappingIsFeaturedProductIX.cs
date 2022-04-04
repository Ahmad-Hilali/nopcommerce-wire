using FluentMigrator;
using BWire.Core.Domain.Catalog;
using BWire.Data.Mapping;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647937")]
    public class AddProductCategoryMappingIsFeaturedProductIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_Product_Category_Mapping_IsFeaturedProduct").OnTable(NameCompatibilityManager.GetTableName(typeof(ProductCategory)))
                .OnColumn(nameof(ProductCategory.IsFeaturedProduct)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}