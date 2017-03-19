using System.Web.Mvc;
using XCode.RuningCode.Service;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IUserService userService;

        public HomeController(IUserService userService, ITest service)
        {
            this.userService = userService;
            this.service = service;
        }

        private ITest service;

        // GET: Home
        public ActionResult Index()
        {
            //var test = userService.Get();
            var entity= service.Get();
            return View();
        }
    }
}