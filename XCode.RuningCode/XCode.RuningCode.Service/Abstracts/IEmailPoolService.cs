using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface IEmailPoolService
    {
        /// <summary>
        /// 获取指定数量的待发送邮件
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        List<EmailPoolDto> GetWithReceivers(int top);

        /// <summary>
		/// 添加emailpool
		/// </summary>
		/// <param name="emailpool">emailpool实体</param>
		/// <returns></returns>
		void Add(EmailPoolDto emailpool);

        /// <summary>
        /// 批量添加emailpool
        /// </summary>
        /// <param name="models">emailpool集合</param>
        /// <returns></returns>
        void Add(List<EmailPoolDto> models);

        /// <summary>
        /// 编辑emailpool
        /// </summary>
        /// <param name="emailpool">实体</param>
        /// <returns></returns>
        void Update(EmailPoolDto emailpool);

        /// <summary>
        /// 批量更新emailpool
        /// </summary>
        /// <param name="emailpools">emailpool实体集合</param>
        /// <returns></returns>
        void Update(IEnumerable<EmailPoolDto> emailpools);

        /// <summary>
        /// 删除emailpool
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// 批量删除emailpool
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        void Delete(Expression<Func<EmailPoolDto, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 emailpool 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        EmailPoolDto GetOne(Expression<Func<EmailPoolDto, bool>> exp);

        /// <summary>
        /// 查询符合调价的 emailpool
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<EmailPoolDto> Query<OrderKeyType>(Expression<Func<EmailPoolDto, bool>> exp, Expression<Func<EmailPoolDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailpool
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<EmailPoolDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<EmailPoolDto, bool>> exp, Expression<Func<EmailPoolDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailpool
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<EmailPoolDto> GetWithPages(QueryBase queryBase, Expression<Func<EmailPoolDto, bool>> exp, string orderBy, string orderDir = "desc");

    }
}
