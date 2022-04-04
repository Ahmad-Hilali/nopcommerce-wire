using System;
using BWire.Web.Framework.Models;

namespace BWire.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a BWire news details model
    /// </summary>
    public partial class BWireNewsDetailsModel : BaseNopModel
    {
        #region Properties

        public string Title { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        #endregion
    }
}