using System.Collections.Generic;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public partial interface IUserService
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
        ResultDto<RoleDto> GetMyRoles(QueryBase query,int userId);

        /// <summary>
        /// 获取我尚未拥有的权限
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultDto<RoleDto> GetNotMyRoles(QueryBase query, int userId);
    }
}
