using FluentMigrator;
using BWire.Core.Domain.Forums;
using BWire.Data.Mapping;

namespace BWire.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037698")]
    public class AddForumsGroupDisplayOrderIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_Forums_Group_DisplayOrder").OnTable(NameCompatibilityManager.GetTableName(typeof(ForumGroup)))
                .OnColumn(nameof(ForumGroup.DisplayOrder)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}