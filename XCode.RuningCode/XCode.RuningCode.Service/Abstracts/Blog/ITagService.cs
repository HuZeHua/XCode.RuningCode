using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface ITagService
    {
        /// <summary>
        /// 添加tag
        /// </summary>
        /// <param name="tag">tag实体</param>
        /// <returns></returns>
        void Add(TagDto tag);

        /// <summary>
        /// 批量添加tag
        /// </summary>
        /// <param name="models">tag集合</param>
        /// <returns></returns>
        void Add(List<TagDto> models);

        /// <summary>
        /// 编辑tag
        /// </summary>
        /// <param name="tag">实体</param>
        /// <returns></returns>
        void Update(TagDto tag);

        /// <summary>
        /// 批量更新tag
        /// </summary>
        /// <param name="tags">tag实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<TagDto> tags);

        /// <summary>
        /// 删除tag
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除tag
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<TagDto, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 tag 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        TagDto GetOne(Expression<Func<TagDto, bool>> exp);

        /// <summary>
        /// 查询符合调价的 tag
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<TagDto> Query<OrderKeyType>(Expression<Func<TagDto, bool>> exp, Expression<Func<TagDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取tag
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<TagDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<TagDto, bool>> exp, Expression<Func<TagDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取tag
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<TagDto> GetWithPages(QueryBase queryBase, Expression<Func<TagDto, bool>> exp, string orderBy, string orderDir = "desc");

        TagDto Get();
    }
}
