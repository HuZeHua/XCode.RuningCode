using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    public class LoginlogController : AdmBaseController
    {
        public ILoginLogService loginLogService;

        #region Page

        // GET: Adm/LoginLog
        public LoginlogController(IPageViewService pageViewService, IMenuService menuService, IUserService userService) : base(pageViewService, menuService, userService)
        {
        }

        public ActionResult Index(string moudleId, string menuId, string btnId)
        {
            return View();
        }

        #endregion

        public LoginlogController(IPageViewService pageViewService, IMenuService menuService, IUserService userService, ILoginLogService loginLogService) : base(pageViewService, menuService, userService)
        {
            this.loginLogService = loginLogService;
        }

        #region Ajax

        public JsonResult GetList(string moudleId, string menuId, string btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<LoginLogDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.SearchKey));

            var dto = loginLogService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}