using System.Web.Mvc;
using XCode.RuningCode.Service;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ITest serTest;
        private IMenuService menuService;

        public HomeController(ITest serTest, IMenuService menuService)
        {
            this.serTest = serTest;
            this.menuService = menuService;
        }

        public ActionResult Index()
        {
            var entity = serTest.Get();
            var test = menuService.Get();
            return View();
        }
    }
}