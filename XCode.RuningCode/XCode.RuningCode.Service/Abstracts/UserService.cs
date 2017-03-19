using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using AutoMapper;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Core.Log;
using XCode.RuningCode.Data;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Service.Abstracts
{
    public partial class UserService : IDependency, IUserService
    {
        public IMenuService menuService { get; set; }

        public IRoleService roleService { get; set; }

        public IUserRoleService userRoleService { get; set; }

        public IRoleMenuService roleMenuService { get; set; }

        public ILoginLogService loginLogService { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Result<UserDto> Login(UserDto dto)
        {
            var res = new Result<UserDto>();
            try
            {
                var user = GetOne(item => item.LoginName == dto.LoginName);
                if (user == null)
                    res.msg = "无效的用户";
                else
                {
                    //记录登录日志
                    loginLogService.Add(new LoginLogDto
                    {
                        UserId = user.Id,
                        LoginName = user.LoginName,
                        IP = WebHelper.GetClientIP(),
                        Mac = WebHelper.GetClientMACAddress()
                    });
                    if (user.Password != dto.Password.ToMD5())
                        res.msg = "登录密码错误";
                    else if (user.IsDeleted)
                        res.msg = "用户已被删除";
                    else if (user.Status == UserStatus.未激活)
                        res.msg = "账号未被激活";
                    else if (user.Status == UserStatus.禁用)
                        res.msg = "账号被禁用";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = user;

                        //写入注册信息
                        DateTime expiration = dto.IsRememberMe
                            ? DateTime.Now.AddDays(7)
                            : DateTime.Now.Add(FormsAuthentication.Timeout);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                            user.LoginName,
                            DateTime.Now,
                            expiration,
                            true,
                            user.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };

#if !DEBUG
                cookie.Domain = FormsAuthentication.CookieDomain;
#endif

                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                Logger.Log(ex.Message, ex);
            }
            return res;
        }

        /// <summary>
        ///     用户退出
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 获取我的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MenuDto> GetMyMenus(int userId)
        {
            //获取我的角色
            var userRoles = userRoleService.Query(item => !item.IsDeleted && item.UserId == userId, item => item.Id, false);
            var roleIds = userRoles.Select(item => item.RoleId).Distinct();
            //获取我的角色权限
            var roleMenus = roleMenuService.Query(item => !item.IsDeleted && roleIds.Contains(item.RoleId),
                item => item.Id, false);
            var menuIds = roleMenus.Select(item => item.MenuId).Distinct();

            return menuService.Query(item => !item.IsDeleted && menuIds.Contains(item.Id), item => item.Order, false);
        }

        /// <summary>
        /// 获取我的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetMyRoles(QueryBase query, int userId)
        {
            var userRoleDbSet = userRoleRepository.Table.AsNoTracking().OrderBy(item => item.CreateDateTime)
                .Where(item => item.UserId == userId).ToList();
            var roleIds = userRoleDbSet.Select(item => item.RoleId).Distinct().ToList();

            Expression<Func<RoleDto, bool>> exp = item => (!item.IsDeleted && roleIds.Contains(item.Id));
            if (!query.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(query.SearchKey));
            var where = exp.Cast<RoleDto, Role, bool>();
            var roleDbSet = rolelRepository.Table
                .AsNoTracking()
                .OrderBy(item => item.CreateDateTime)
                .Where(where);
            var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();

            var dto = new ResultDto<RoleDto>
            {
                recordsTotal = roleDbSet.Count(),
                data = Mapper.Map<List<Role>, List<RoleDto>>(list)
            };
            return dto;


        }

        /// <summary>
        /// 获取我尚未拥有的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetNotMyRoles(QueryBase query, int userId)
        {

            var userRoleDbSet = userRoleRepository.Table.AsNoTracking().OrderBy(item => item.CreateDateTime)
                    .Where(item => item.UserId == userId).ToList();
            var roleIds = userRoleDbSet.Select(item => item.RoleId).Distinct().ToList();

            Expression<Func<RoleDto, bool>> exp = item => (!item.IsDeleted && !roleIds.Contains(item.Id));
            if (!query.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(query.SearchKey));
            var where = exp.Cast<RoleDto, Role, bool>();
            var roleDbSet = rolelRepository.Table
                .AsNoTracking()
                .OrderBy(item => item.CreateDateTime)
                .Where(where);
            var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();

            var dto = new ResultDto<RoleDto>
            {
                recordsTotal = roleDbSet.Count(),
                data = Mapper.Map<List<Role>, List<RoleDto>>(list)
            };
            return dto;
        }
    }
}
