﻿using System;
using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Logging
{
    /// <summary>
    /// Represents an activity log model
    /// </summary>
    public partial class ActivityLogModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.ActivityLogType")]
        public string ActivityLogTypeName { get; set; }

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.Customer")]
        public int CustomerId { get; set; }

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.CustomerEmail")]
        public string CustomerEmail { get; set; }

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.Comment")]
        public string Comment { get; set; }

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [NopResourceDisplayName("Admin.Customers.ActivityLog.Fields.IpAddress")]
        public string IpAddress { get; set; }

        #endregion
    }
}