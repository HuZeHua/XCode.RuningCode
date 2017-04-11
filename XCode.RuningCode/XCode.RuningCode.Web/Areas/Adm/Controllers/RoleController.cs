using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Web.Models;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    [NavigateName("角色管理", MenuType.Module, MenuName.BlogSetting)]
    public class RoleController : AdmBaseController
    {
        private readonly IRoleService roleService;
        private readonly IRoleMenuService roleMenuService;
        private readonly IMenuService menuService;
        private readonly INavigateService navigate_service;

        public RoleController(IRoleService role_service, IRoleMenuService role_menu_service, IMenuService menu_service, INavigateService navigate_service)
        {
            roleService = role_service;
            roleMenuService = role_menu_service;
            menuService = menu_service;
            this.navigate_service = navigate_service;
        }
        
        #region Page

        [NavigateName("角色管理", MenuType.Menu)]
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }

        [NavigateName("添加")]
        public ActionResult Add(string moudleId, string menuId, string btnId)
        {
            return View();
        }

        [NavigateName("修改")]
        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            var model = roleService.GetOne(item => item.Id == id);
            return View(model);
        }
        [NavigateName("角色授权",MenuType.Menu)]
        public ActionResult AuthMenus(int moudleId, int menuId, int btnId)
        {
            ViewBag.Menus = navigate_service.Query(item => !item.IsDeleted, item => item.Id, false);
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
            Expression<Func<RoleDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(queryBase.SearchKey));

            var dto = roleService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(int moudleId, int menuId, int btnId, RoleDto dto)
        {
            roleService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }

        [HttpPost]
        public ActionResult Edit(int moudleId, int menuId, int btnId, RoleDto dto)
        {
            roleService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }

        [NavigateName("删除")]
        [HttpPost]
        public JsonResult Delete(int moudleId, int menuId, int btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                roleService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AuthMenus(int moudleId, int menuId, int btnId, AuthNavigateDto dto)
        {
            var res = new Result<int>();

            foreach (var roleId in dto.RoleIds)
            {
                roleService.delete_navigate(roleId);
                roleService.add_navigate(roleId,dto.NavigateIds);
            }

            res.flag = true;

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRoleMenusByRoleId(int moudleId, int menuId, int btnId, int id)
        {
            var res = new Result<List<RoleMenuDto>>();
            var list = roleMenuService.Query(item => item.RoleId == id, item => item.Id, false);
            res.flag = true;
            res.data = list;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}