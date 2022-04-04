using FluentMigrator.Builders.Create.Table;
using BWire.Core.Domain.Customers;
using BWire.Core.Domain.Security;
using BWire.Data.Extensions;

namespace BWire.Data.Mapping.Builders.Security
{
    /// <summary>
    /// Represents a permission record customer role mapping entity builder
    /// </summary>
    public partial class PermissionRecordCustomerRoleMappingBuilder : NopEntityBuilder<PermissionRecordCustomerRoleMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(PermissionRecordCustomerRoleMapping), nameof(PermissionRecordCustomerRoleMapping.PermissionRecordId)))
                    .AsInt32().PrimaryKey().ForeignKey<PermissionRecord>()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(PermissionRecordCustomerRoleMapping), nameof(PermissionRecordCustomerRoleMapping.CustomerRoleId)))
                    .AsInt32().PrimaryKey().ForeignKey<CustomerRole>();
        }

        #endregion
    }
}