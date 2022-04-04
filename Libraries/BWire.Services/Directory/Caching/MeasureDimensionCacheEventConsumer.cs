using BWire.Core.Domain.Directory;
using BWire.Services.Caching;

namespace BWire.Services.Directory.Caching
{
    /// <summary>
    /// Represents a measure dimension cache event consumer
    /// </summary>
    public partial class MeasureDimensionCacheEventConsumer : CacheEventConsumer<MeasureDimension>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(MeasureDimension entity)
        {
            Remove(NopDirectoryDefaults.MeasureDimensionsAllCacheKey);
        }
    }
}
