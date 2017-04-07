using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    [NavigateName("访问日志", MenuType.Module, MenuName.Log)]
    public class PageViewController : AdmBaseController
    {

        #region Page

        private readonly IPageViewService pageViewService;
        // GET: Adm/PageView
        public PageViewController(IPageViewService pageViewService)
        {
            this.pageViewService = pageViewService;
        }
        [NavigateName("访问日志", MenuType.Menu)]
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            return View();
        }

        #endregion

        #region Ajax

        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<PageViewDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.SearchKey));

            var dto = pageViewService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}