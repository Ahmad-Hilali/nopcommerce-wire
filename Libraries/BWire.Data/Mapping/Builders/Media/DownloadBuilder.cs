using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Media;

namespace BWire.Data.Mapping.Builders.Media
{
    /// <summary>
    /// Represents a download entity builder
    /// </summary>
    public partial class DownloadBuilder : NopEntityBuilder<Download>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
        }

        #endregion
    }
}