using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using AutoMapper;
using AutoMapper.Internal;
using EntityFramework.Extensions;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Core.Log;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Service.Implements
{
    public class UserService : IDependency, IUserService
    {
        public IMenuService menuService;
        public IRoleService roleService;
        public IUserRoleService userRoleService;
        public IRoleMenuService roleMenuService;
        public ILoginLogService loginLogService;
        private IRepository<User> repository;
        private IRepository<UserRole> userRoleRepository;
        private IRepository<Role> rolelRepository;

        #region IUserService 接口实现

        public UserService(IMenuService menuService, IRoleService roleService, IUserRoleService userRoleService, IRoleMenuService roleMenuService, ILoginLogService loginLogService, IRepository<User> repository, IRepository<UserRole> userRoleRepository, IRepository<Role> rolelRepository)
        {
            this.menuService = menuService;
            this.roleService = roleService;
            this.userRoleService = userRoleService;
            this.roleMenuService = roleMenuService;
            this.loginLogService = loginLogService;
            this.repository = repository;
            this.userRoleRepository = userRoleRepository;
            this.rolelRepository = rolelRepository;
        }

        /// <summary>
        /// 添加user
        /// </summary>
        /// <param name="dto">user实体</param>
        /// <returns></returns>
        public void Add(UserDto dto)
        {
            var entity = Mapper.Map<UserDto, User>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加user
        /// </summary>
        /// <param name="dtos">user集合</param>
        /// <returns></returns>
        public void Add(List<UserDto> dtos)
        {
            var entities = Mapper.Map<List<UserDto>, List<User>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑user
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(UserDto dto)
        {
            var entity = Mapper.Map<UserDto, User>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新user
        /// </summary>
        /// <param name="dtos">user实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<UserDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>(dtos);
            entities.Each(x => repository.Update(x));

        }

        /// <summary>
        /// 删除user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除user
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<UserDto, bool>> exp)
        {
            var where = exp.Cast<UserDto, User, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 user 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public UserDto GetOne(Expression<Func<UserDto, bool>> exp)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var entity = repository.GetOne(where);
            return Mapper.Map<User, UserDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 user
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<UserDto> Query<OrderKeyType>(Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var order = orderExp.Cast<UserDto, User, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<User>, List<UserDto>>(list);
        }

        /// <summary>
        /// 分页获取User
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<UserDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var order = orderExp.Cast<UserDto, User, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<User>, List<UserDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取User
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<UserDto> GetWithPages(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<UserDto, User, bool>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<User>, List<UserDto>>(list)
            };
            return dto;
        }

        public UserDto Get()
        {
            return Mapper.Map<User, UserDto>(repository.Table.FirstOrDefault());
        }

        #endregion

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
