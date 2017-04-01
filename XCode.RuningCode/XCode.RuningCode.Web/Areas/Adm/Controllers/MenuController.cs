using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    public class MenuController : AdmBaseController
    {

        #region Page

        private readonly IMenuService menuService;
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int moudleId, int menuId, int btnId)
        {
            ViewBag.ParentMenu = menuService.Query(item => !item.IsDeleted && item.Type != MenuType.ButtonType, item => item.Id,
                false);
            return View();
        }

        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            ViewBag.ParentMenu = menuService.Query(item => !item.IsDeleted && item.Type != MenuType.ButtonType, item => item.Id,
               false);
            var model = menuService.GetOne(item => item.Id == id);
            return View(model);
        }

        #endregion

        #region Ajax

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, MenuDto dto)
        {
            SetMenuType(ref dto);
            menuService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, MenuDto dto)
        {
            SetMenuType(ref dto);
            menuService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                menuService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        

        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId,string id)
        {
            //var parentId = id.ToInt();
            //var list = menuService.Query(item => !item.IsDeleted && item.ParentId == parentId, item => item.Id);
            //var dtos = new List<MenuDto>();
            //list.ForEach(item =>
            //{
            //    var dto = new MenuDto
            //    {
            //        id = item.Id.ToString(),
            //        name = item.Name,
            //        type = "folder",
            //        additionalParameters = new AdditionalParameters {id = item.Id.ToString()}
            //    };
            //    dtos.Add(dto);
            //});

            //return Json(dtos, JsonRequestBehavior.AllowGet);

            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<MenuDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(queryBase.SearchKey));

            var dto = menuService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        void SetMenuType(ref MenuDto dto)
        {
            var parentId = dto.ParentId;
            var parent = menuService.GetOne(item => item.Id == parentId);
            if (parentId<=0|| parent==null)
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

        #endregion
    }
}