using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Catalog;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a specification attribute option entity builder
    /// </summary>
    public partial class SpecificationAttributeOptionBuilder : NopEntityBuilder<SpecificationAttributeOption>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(SpecificationAttributeOption.Name)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(SpecificationAttributeOption.ColorSquaresRgb)).AsString(100).Nullable()
                .WithColumn(nameof(SpecificationAttributeOption.SpecificationAttributeId)).AsInt32().ForeignKey<SpecificationAttribute>();
        }

        #endregion
    }
}