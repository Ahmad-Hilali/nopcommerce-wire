using System.Data;
using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Affiliates;
using BWire.Core.Domain.Common;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Affiliates
{
    /// <summary>
    /// Represents a affiliate entity builder
    /// </summary>
    public class AffiliateBuilder : NopEntityBuilder<Affiliate>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Affiliate.AddressId)).AsInt32().ForeignKey<Address>().OnDelete(Rule.None);
        }

        #endregion
    }
}