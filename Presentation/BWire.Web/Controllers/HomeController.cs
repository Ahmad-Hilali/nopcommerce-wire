using Microsoft.AspNetCore.Mvc;

namespace BWire.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}