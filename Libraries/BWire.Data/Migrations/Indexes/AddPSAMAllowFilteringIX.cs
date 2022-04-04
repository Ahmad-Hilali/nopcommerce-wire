using FluentMigrator;
using FluentMigrator.SqlServer;
using BWire.Core.Domain.Catalog;
using BWire.Data.Mapping;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 12:02:35:9280391")]
    public class AddPSAMAllowFilteringIX : AutoReversingMigration
    {
        #region Methods         

        public override void Up()
        {
            Create.Index("IX_PSAM_AllowFiltering").OnTable(NameCompatibilityManager.GetTableName(typeof(ProductSpecificationAttribute)))
                .OnColumn(nameof(ProductSpecificationAttribute.AllowFiltering)).Ascending()
                .WithOptions().NonClustered()
                .Include(nameof(ProductSpecificationAttribute.ProductId))
                .Include(nameof(ProductSpecificationAttribute.SpecificationAttributeOptionId));
        }

        #endregion
    }
}