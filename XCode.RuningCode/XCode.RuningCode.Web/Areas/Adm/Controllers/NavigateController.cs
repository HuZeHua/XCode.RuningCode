using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    public class NavigateController : AdmBaseController
    {

        private readonly INavigateService service;

        public NavigateController(INavigateService service)
        {
            this.service = service;
        }


        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }


        public ActionResult Add(int moudleId, int menuId, int btnId)
        {
            ViewBag.ParentMenu = service.Query(item => !item.IsDeleted && item.Type != MenuType.ButtonType, item => item.Id,
                false);
            return View();
        }

        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            ViewBag.ParentMenu = service.Query(item => !item.IsDeleted && item.Type != MenuType.ButtonType, item => item.Id,
               false);
            var model = service.GetOne(item => item.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, NavigateDto dto)
        {
            SetMenuType(ref dto);
            service.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, NavigateDto dto)
        {
            SetMenuType(ref dto);
            service.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                service.Delete(item => ids.Contains(item.Id));
            res.data = "删除成功";
            res.flag = true;

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId, string id)
        {

            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<NavigateDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(queryBase.SearchKey));

            var dto = service.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        void SetMenuType(ref NavigateDto dto)
        {
            var parentId = dto.Parent.Id;
            var parent = service.GetOne(item => item.Id == parentId);
            if (parentId <= 0 || parent == null)
                dto.Type = MenuType.Module;
            else
            {
                switch (parent.Type)
                {
                    case MenuType.Module:
                        dto.Type = MenuType.Menu;
                        break;
                    case MenuType.Menu:
                        dto.Type = MenuType.ButtonType;
                        break;
                }
            }
        }
    }
}