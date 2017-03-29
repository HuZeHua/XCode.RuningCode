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
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    /// <summary>
    /// LoginLog业务契约
    /// </summary>
    public class LoginLogService : IDependency, ILoginLogService
    {
        private readonly IRepository<LoginLog> repository;

        public LoginLogService(IRepository<LoginLog> repository)
        {
            this.repository = repository;
        }

        #region ILoginLogService 接口实现

        /// <summary>
        /// 添加loginlog
        /// </summary>
        /// <param name="dto">loginlog实体</param>
        /// <returns></returns>
        public void Add(LoginLogDto dto)
        {
            var entity = Mapper.Map<LoginLogDto, LoginLog>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加loginlog
        /// </summary>
        /// <param name="dtos">loginlog集合</param>
        /// <returns></returns>
        public void Add(List<LoginLogDto> dtos)
        {
            var entities = Mapper.Map<List<LoginLogDto>, List<LoginLog>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑loginlog
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(LoginLogDto dto)
        {
            var entity = Mapper.Map<LoginLogDto, LoginLog>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新loginlog
        /// </summary>
        /// <param name="dtos">loginlog实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<LoginLogDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<LoginLogDto>, IEnumerable<LoginLog>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除loginlog
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除loginlog
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<LoginLogDto, bool>> exp)
        {
            var where = exp.Cast<LoginLogDto, LoginLog, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 loginlog 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public LoginLogDto GetOne(Expression<Func<LoginLogDto, bool>> exp)
        {
            var where = exp.Cast<LoginLogDto, LoginLog, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<LoginLog, LoginLogDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 loginlog
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<LoginLogDto> Query<OrderKeyType>(Expression<Func<LoginLogDto, bool>> exp, Expression<Func<LoginLogDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<LoginLogDto, LoginLog, bool>();
            var order = orderExp.Cast<LoginLogDto, LoginLog, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<LoginLog>, List<LoginLogDto>>(list);
        }

        /// <summary>
        /// 分页获取LoginLog
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<LoginLogDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<LoginLogDto, bool>> exp, Expression<Func<LoginLogDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<LoginLogDto, LoginLog, bool>();
            var order = orderExp.Cast<LoginLogDto, LoginLog, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<LoginLogDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<LoginLog>, List<LoginLogDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取LoginLog
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<LoginLogDto> GetWithPages(QueryBase queryBase, Expression<Func<LoginLogDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<LoginLogDto, LoginLog, bool>();
            //var order = orderExp.Cast<LoginLogDto, LoginLogEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<LoginLogDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<LoginLog>, List<LoginLogDto>>(list)
            };
            return dto;
        }

        #endregion
    }
}
