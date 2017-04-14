using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface IArticleService
    {
        /// <summary>
        /// 添加article
        /// </summary>
        /// <param name="article">article实体</param>
        /// <returns></returns>
        void Add(ArticleDto article);

        /// <summary>
        /// 批量添加article
        /// </summary>
        /// <param name="models">article集合</param>
        /// <returns></returns>
        void Add(List<ArticleDto> models);

        /// <summary>
        /// 编辑article
        /// </summary>
        /// <param name="article">实体</param>
        /// <returns></returns>
        void Update(ArticleDto article);

        /// <summary>
        /// 批量更新article
        /// </summary>
        /// <param name="articles">article实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<ArticleDto> articles);

        /// <summary>
        /// 删除article
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除article
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<ArticleDto, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 article 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        ArticleDto GetOne(Expression<Func<ArticleDto, bool>> exp);

        /// <summary>
        /// 查询符合调价的 article
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<ArticleDto> Query<OrderKeyType>(Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取article
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<ArticleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取article
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<ArticleDto> GetWithPages(QueryBase queryBase, Expression<Func<ArticleDto, bool>> exp, string orderBy, string orderDir = "desc");

        ArticleDto Get();

        ArticleDto get_by_id(int id);
        void add_view(int id);
        List<ArticleDto> Query(Expression<Func<ArticleDto, bool>> exp);
        List<ArticleDto> get_article_by_tag(int value);
        List<ArticleDto> Query<OrderKeyType>(Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool is_desc, int count);
    }
}
