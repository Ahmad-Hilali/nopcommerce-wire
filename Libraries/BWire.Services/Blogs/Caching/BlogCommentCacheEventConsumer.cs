using BWire.Core.Domain.Blogs;
using BWire.Services.Caching;

namespace BWire.Services.Blogs.Caching
{
    /// <summary>
    /// Represents a blog comment cache event consumer
    /// </summary>
    public partial class BlogCommentCacheEventConsumer : CacheEventConsumer<BlogComment>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(BlogComment entity)
        {
            RemoveByPrefix(string.Format(NopBlogsDefaults.BlogCommentsNumberPrefixCacheKey, entity.BlogPostId));
        }
    }
}