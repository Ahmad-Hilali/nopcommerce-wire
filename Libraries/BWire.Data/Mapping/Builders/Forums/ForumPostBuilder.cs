using System.Data;
using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Forums;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Forums
{
    /// <summary>
    /// Represents a forum post entity builder
    /// </summary>
    public partial class ForumPostBuilder : NopEntityBuilder<ForumPost>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ForumPost.Text)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(ForumPost.IPAddress)).AsString(100).Nullable()
                .WithColumn(nameof(ForumPost.CustomerId)).AsInt32().ForeignKey<Customer>().OnDelete(Rule.None)
                .WithColumn(nameof(ForumPost.TopicId)).AsInt32().ForeignKey<ForumTopic>();
        }

        #endregion
    }
}