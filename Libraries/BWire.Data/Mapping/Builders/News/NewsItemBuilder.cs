using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Localization;
using BWire.Core.Domain.News;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.News
{
    /// <summary>
    /// Represents a news item entity builder
    /// </summary>
    public partial class NewsItemBuilder : NopEntityBuilder<NewsItem>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(NewsItem.Title)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.Short)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.Full)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(NewsItem.MetaKeywords)).AsString(400).Nullable()
                .WithColumn(nameof(NewsItem.MetaTitle)).AsString(400).Nullable()
                .WithColumn(nameof(NewsItem.LanguageId)).AsInt32().ForeignKey<Language>();
        }

        #endregion
    }
}