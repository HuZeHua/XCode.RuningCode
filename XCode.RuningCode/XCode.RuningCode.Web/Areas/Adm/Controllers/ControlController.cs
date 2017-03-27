using System.Web.Mvc;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    public class ControlController : AdmBaseController
    {
        public ControlController(IPageViewService pageViewService, IMenuService menuService, IUserService userService, IAuthorizeProvider provider) 
            : base(pageViewService, menuService, userService, provider)
        {
        }

        // GET: Adm/Control
        public ActionResult Index()
        {
            if (IsLogined)
            {
                //获取拥有的角色
                var userid = CurrentUser.Id;
                ViewBag.MyMenus = userService.GetMyMenus(userid);
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