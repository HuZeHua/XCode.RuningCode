﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using XCode.RuningCode.Core.Attributes;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    [NavigateName("用户管理", MenuType.Module, MenuName.SystemSetting)]
    public class UserManageController : AdmBaseController
    {
        private readonly IUserService userService;
        private readonly IAuthorizeProvider provider;

        public UserManageController(IUserService userService, IAuthorizeProvider provider)
        {
            this.userService = userService;
            this.provider = provider;
        }

        #region Page

        [NavigateName("用户管理", MenuType.Menu)]
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }

        [NavigateName("添加")]
        public ActionResult Add(int moudleId, int menuId, int btnId)
        {
            return View();
        }
        [NavigateName("修改")]
        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            var model = userService.GetOne(item => item.Id == id);
            return View(model);
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <param name="moudleId"></param>
        /// <param name="menuId"></param>
        /// <param name="btnId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Authen(int moudleId, int menuId, int btnId, int id)
        {
            return View();
        }
        
        #endregion

        #region Ajax

        [HttpGet]
        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<UserDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.SearchKey) || item.RealName.Contains(queryBase.SearchKey));

            var dto = userService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            var res = new ResultDto<UserDto>
            {
                start = dto.start,
                length = dto.length,
                recordsTotal = dto.recordsTotal,
                data = dto.data.Select(d => new UserDto
                {
                    Id = d.Id,
                    LoginName = d.LoginName,
                    RealName = d.RealName,
                    Email = d.Email,
                    CreateDateTime = d.CreateDateTime,
                    Status = d.Status,
                    IsDeleted = d.IsDeleted
                }).ToList()
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMyRoles(int moudleId, int menuId, int btnId, int id)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };

            var dto = userService.GetMyRoles(queryBase, id);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNotMyRoles(int moudleId, int menuId, int btnId, int id)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };

            var dto = userService.GetNotMyRoles(queryBase, id);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AuthenRole(int moudleId, int menuId, int btnId, int id, List<RoleDto> roles)
        {
            var dto = new Result<string>();
            userService.AddRoles(id, roles);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UnAuthenRole(string moudleId, string menuId, string btnId, string id, List<RoleDto> roles)
        {
            var dto = new Result<string>();
            userService.delete_authenr_role(id, roles);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(int moudleId, int menuId, int btnId, UserDto dto)
        {
            dto.Password = dto.Password.ToMD5();
            userService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, UserDto dto)
        {
            var old = userService.GetOne(item => item.Id == dto.Id);
            dto.Password = dto.Password.IsBlank() ? old.Password : dto.Password.ToMD5();
            userService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }

        [NavigateName("删除")]
        [HttpPost]
        public JsonResult Delete(int moudleId, int menuId, int btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                userService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public JsonResult GetTestData()
        {
            List<UserDto> users = new List<UserDto>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserDto()
                {
                    LoginName = "i" + i,
                    Id = i
                });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}