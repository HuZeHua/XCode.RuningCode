using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{ 
	/// <summary>
    /// Menu业务契约
    /// </summary>
    public interface INavigateService
    {
		/// <summary>
		/// 添加menu
		/// </summary>
		/// <param name="menu">menu实体</param>
		/// <returns></returns>
		void Add(NavigateDto menu);

        /// <summary>
        /// 批量添加menu
        /// </summary>
        /// <param name="models">menu集合</param>
        /// <returns></returns>
        void Add(List<NavigateDto> models);

        /// <summary>
        /// 编辑menu
        /// </summary>
        /// <param name="menu">实体</param>
        /// <returns></returns>
        void Update(NavigateDto menu);

        /// <summary>
        /// 批量更新menu
        /// </summary>
        /// <param name="menus">menu实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<NavigateDto> menus);

        /// <summary>
        /// 删除menu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除menu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<NavigateDto, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 menu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        NavigateDto GetOne(Expression<Func<NavigateDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 menu
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<NavigateDto> Query<OrderKeyType>(Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<NavigateDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<NavigateDto> GetWithPages(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, string orderBy, string orderDir = "desc");

        NavigateDto Get();
    } 
}
