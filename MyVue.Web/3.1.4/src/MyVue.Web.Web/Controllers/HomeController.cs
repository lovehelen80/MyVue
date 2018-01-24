using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MyVue.Web.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : WebControllerBase
    {
        public ActionResult Index()
        {
            Response.Redirect("/MyVue/dist/index.html");
            return View();
        }
    }
}