using System.Data;
using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Forums;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Forums
{
    /// <summary>
    /// Represents a forum subscription entity builder
    /// </summary>
    public partial class ForumSubscriptionBuilder : NopEntityBuilder<ForumSubscription>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(ForumSubscription.CustomerId)).AsInt32().ForeignKey<Customer>(onDelete: Rule.None);
        }

        #endregion
    }
}