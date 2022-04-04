using Microsoft.AspNetCore.Mvc;
using BWire.Web.Areas.Admin.Factories;
using BWire.Web.Framework.Components;

namespace BWire.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays the BWire news
    /// </summary>
    public class BWireNewsViewComponent : NopViewComponent
    {
        #region Fields

        private readonly IHomeModelFactory _homeModelFactory;

        #endregion

        #region Ctor

        public BWireNewsViewComponent(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke()
        {
            try
            {
                //prepare model
                var model = _homeModelFactory.PrepareBWireNewsModel();

                return View(model);
            }
            catch
            {
                return Content(string.Empty);
            }
        }

        #endregion
    }
}