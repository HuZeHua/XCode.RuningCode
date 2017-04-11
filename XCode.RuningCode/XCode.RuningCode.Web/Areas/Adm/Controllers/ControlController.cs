using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    public class ControlController : AdmBaseController
    {
        private readonly IUserService userService;
        public ControlController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: Adm/Control
        public ActionResult Index()
        {
            if (IsLogined)
            {
                //获取拥有的角色
                var userid = CurrentUser.Id;
                ViewBag.MyMenus = userService.GetMyNavigates(userid);
            }
            return View();
        }

        /// <summary>
        /// Welcome
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            return View();
        }
    }
}