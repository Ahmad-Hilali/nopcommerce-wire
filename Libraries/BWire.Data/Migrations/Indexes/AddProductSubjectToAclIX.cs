using FluentMigrator;
using BWire.Core.Domain.Catalog;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647936")]
    public class AddProductSubjectToAclIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_Product_SubjectToAcl").OnTable(nameof(Product))
                .OnColumn(nameof(Product.SubjectToAcl)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}