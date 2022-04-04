using BWire.Core.Domain.Security;
using BWire.Services.Caching;

namespace BWire.Services.Security.Caching
{
    /// <summary>
    /// Represents a permission record-customer role mapping cache event consumer
    /// </summary>
    public partial class PermissionRecordCustomerRoleMappingCacheEventConsumer : CacheEventConsumer<PermissionRecordCustomerRoleMapping>
    {
    }
}