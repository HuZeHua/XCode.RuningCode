using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{ 
	/// <summary>
    /// RoleMenu业务契约
    /// </summary>
    public interface IRoleMenuService
    {
		/// <summary>
		/// 添加rolemenu
		/// </summary>
		/// <param name="rolemenu">rolemenu实体</param>
		/// <returns></returns>
		void Add(RoleMenuDto rolemenu);

        /// <summary>
        /// 批量添加rolemenu
        /// </summary>
        /// <param name="models">rolemenu集合</param>
        /// <returns></returns>
        void Add(List<RoleMenuDto> models);

        /// <summary>
        /// 编辑rolemenu
        /// </summary>
        /// <param name="rolemenu">实体</param>
        /// <returns></returns>
        void Update(RoleMenuDto rolemenu);

        /// <summary>
        /// 批量更新rolemenu
        /// </summary>
        /// <param name="rolemenus">rolemenu实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<RoleMenuDto> rolemenus);

        /// <summary>
        /// 删除rolemenu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除rolemenu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<RoleMenuDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 rolemenu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        RoleMenuDto GetOne(Expression<Func<RoleMenuDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 rolemenu
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<RoleMenuDto> Query<OrderKeyType>(Expression<Func<RoleMenuDto, bool>> exp, Expression<Func<RoleMenuDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取rolemenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<RoleMenuDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenuDto, bool>> exp, Expression<Func<RoleMenuDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取rolemenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<RoleMenuDto> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenuDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
