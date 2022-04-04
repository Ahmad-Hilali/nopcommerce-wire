﻿using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an order average report line summary model
    /// </summary>
    public partial class OrderAverageReportModel : BaseNopModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.SalesReport.Average.OrderStatus")]
        public string OrderStatus { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Average.SumTodayOrders")]
        public string SumTodayOrders { get; set; }
        
        [NopResourceDisplayName("Admin.SalesReport.Average.SumThisWeekOrders")]
        public string SumThisWeekOrders { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Average.SumThisMonthOrders")]
        public string SumThisMonthOrders { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Average.SumThisYearOrders")]
        public string SumThisYearOrders { get; set; }

        [NopResourceDisplayName("Admin.SalesReport.Average.SumAllTimeOrders")]
        public string SumAllTimeOrders { get; set; }

        #endregion
    }
}