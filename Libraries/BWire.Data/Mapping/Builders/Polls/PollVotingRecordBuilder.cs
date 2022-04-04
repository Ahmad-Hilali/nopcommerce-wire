using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Polls;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Polls
{
    /// <summary>
    /// Represents a poll voting record entity builder
    /// </summary>
    public partial class PollVotingRecordBuilder : NopEntityBuilder<PollVotingRecord>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(PollVotingRecord.PollAnswerId)).AsInt32().ForeignKey<PollAnswer>()
                .WithColumn(nameof(PollVotingRecord.CustomerId)).AsInt32().ForeignKey<Customer>();
        }

        #endregion
    }
}