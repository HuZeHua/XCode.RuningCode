using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal;
using EntityFramework.Extensions;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Service.Implements
{ 
	/// <summary>
    /// EmailReceiver业务契约
    /// </summary>
    public class EmailReceiverService : IDependency, IEmailReceiverService
    {
	    private IRepository<EmailReceiver> repository;

	    public EmailReceiverService(IRepository<EmailReceiver> repository)
	    {
	        this.repository = repository;
	    }

	    #region IEmailReceiverService 接口实现

		/// <summary>
		/// 添加emailreceiver
		/// </summary>
		/// <param name="dto">emailreceiver实体</param>
		/// <returns></returns>
		public void Add(EmailReceiverDto dto)
		{
            var entity = Mapper.Map<EmailReceiverDto, EmailReceiver>(dto);
            repository.Insert(entity);
        }

		/// <summary>
        /// 批量添加emailreceiver
        /// </summary>
        /// <param name="dtos">emailreceiver集合</param>
        /// <returns></returns>
        public void Add(List<EmailReceiverDto> dtos)
		{
            var entities = Mapper.Map<List<EmailReceiverDto>, List<EmailReceiver>>(dtos);
            repository.Insert(entities);
        }

		/// <summary>
		/// 编辑emailreceiver
		/// </summary>
		/// <param name="dto">实体</param>
		/// <returns></returns>
		public void Update(EmailReceiverDto dto)
		{
            var entity = Mapper.Map<EmailReceiverDto, EmailReceiver>(dto);
            repository.Update(entity);
        }

		/// <summary>
		/// 批量更新emailreceiver
		/// </summary>
		/// <param name="dtos">emailreceiver实体集合</param>
		/// <returns></returns>
		public void Update(IEnumerable<EmailReceiverDto> dtos)
		{
            var entities = Mapper.Map<IEnumerable<EmailReceiverDto>, IEnumerable<EmailReceiver>>(dtos);
            entities.Each(x => repository.Update(x));
        }

		/// <summary>
		/// 删除emailreceiver
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		public void Delete(int id)
		{
            var model = repository.GetById(id);
            repository.Delete(model);
        }

		/// <summary>
        /// 批量删除emailreceiver
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<EmailReceiverDto, bool>> exp)
		{
            var where = exp.Cast<EmailReceiverDto, EmailReceiver, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

		/// <summary>
        ///  获取单条符合条件的 emailreceiver 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public EmailReceiverDto GetOne(Expression<Func<EmailReceiverDto, bool>> exp)
		{
            var where = exp.Cast<EmailReceiverDto, EmailReceiver, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<EmailReceiver, EmailReceiverDto>(entity);
		}

		/// <summary>
        /// 查询符合调价的 emailreceiver
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<EmailReceiverDto> Query<OrderKeyType>(Expression<Func<EmailReceiverDto, bool>> exp, Expression<Func<EmailReceiverDto, OrderKeyType>> orderExp, bool isDesc = true)
		{
            var where = exp.Cast<EmailReceiverDto, EmailReceiver, bool>();
            var order = orderExp.Cast<EmailReceiverDto, EmailReceiver, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<EmailReceiver>, List<EmailReceiverDto>>(list);
		}

		/// <summary>
        /// 分页获取EmailReceiver
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<EmailReceiverDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<EmailReceiverDto, bool>> exp, Expression<Func<EmailReceiverDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<EmailReceiverDto, EmailReceiver, bool>();
            var order = orderExp.Cast<EmailReceiverDto, EmailReceiver, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<EmailReceiverDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<EmailReceiver>, List<EmailReceiverDto>>(list)
            };
            return dto;
        }

		/// <summary>
        /// 分页获取EmailReceiver
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<EmailReceiverDto> GetWithPages(QueryBase queryBase, Expression<Func<EmailReceiverDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<EmailReceiverDto, EmailReceiver, bool>();
            //var order = orderExp.Cast<EmailReceiverDto, EmailReceiverEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<EmailReceiverDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<EmailReceiver>, List<EmailReceiverDto>>(list)
            };
            return dto;
        }

		#endregion
    } 
}
