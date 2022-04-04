using BWire.Web.Areas.Admin.Models.Home;

namespace BWire.Web.Areas.Admin.Factories
{
    /// <summary>
    /// Represents the home models factory
    /// </summary>
    public partial interface IHomeModelFactory
    {
        /// <summary>
        /// Prepare dashboard model
        /// </summary>
        /// <param name="model">Dashboard model</param>
        /// <returns>Dashboard model</returns>
        DashboardModel PrepareDashboardModel(DashboardModel model);

        /// <summary>
        /// Prepare BWire news model
        /// </summary>
        /// <returns>BWire news model</returns>
        BWireNewsModel PrepareBWireNewsModel();
    }
}