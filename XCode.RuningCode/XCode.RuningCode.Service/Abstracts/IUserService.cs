using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Result<UserDto> Login(UserDto dto);

        /// <summary>
        /// 用户退出
        /// </summary>
        void Logout();

        /// <summary>
        /// 获取我的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MenuDto> GetMyMenus(int userId);

        /// <summary>
        /// 获取我的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultDto<RoleDto> GetMyRoles(QueryBase query, int userId);

        /// <summary>
        /// 获取我尚未拥有的权限
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultDto<RoleDto> GetNotMyRoles(QueryBase query, int userId);

        /// <summary>
		/// 添加user
		/// </summary>
		/// <param name="user">user实体</param>
		/// <returns></returns>
		void Add(UserDto user);

        /// <summary>
        /// 批量添加user
        /// </summary>
        /// <param name="models">user集合</param>
        /// <returns></returns>
        void Add(List<UserDto> models);

        /// <summary>
        /// 编辑user
        /// </summary>
        /// <param name="user">实体</param>
        /// <returns></returns>
        void Update(UserDto user);

        /// <summary>
        /// 批量更新user
        /// </summary>
        /// <param name="users">user实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<UserDto> users);

        /// <summary>
        /// 删除user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除user
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<UserDto, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 user 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        UserDto GetOne(Expression<Func<UserDto, bool>> exp);

        /// <summary>
        /// 查询符合调价的 user
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<UserDto> Query<OrderKeyType>(Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取user
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<UserDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取user
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<UserDto> GetWithPages(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, string orderBy, string orderDir = "desc");

        void AddRoles(int user_id, List<RoleDto> roles);
        void delete_authenr_role(string id, List<RoleDto> roles);
    }
}
