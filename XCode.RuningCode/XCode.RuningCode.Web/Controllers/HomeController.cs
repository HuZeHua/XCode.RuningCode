using System.Web.Mvc;
using XCode.RuningCode.Service;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ITest serTest;
        // GET: Home
        public HomeController(ITest serTest)
        {
            this.serTest = serTest;
        }

        public ActionResult Index()
        {
            var entity = serTest.Get();
            return View();
        }
    }
}