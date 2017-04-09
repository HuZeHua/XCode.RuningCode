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
    /// Navigate业务契约
    /// </summary>
    public class NavigateService : IDependency, INavigateService
    {
        private readonly IRepository<Navigate> repository;

        public NavigateService(IRepository<Navigate> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加Navigate
        /// </summary>
        /// <param name="dto">Navigate实体</param>
        /// <returns></returns>
        public void Add(NavigateDto dto)
        {
            var entity = Mapper.Map<NavigateDto, Navigate>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加Navigate
        /// </summary>
        /// <param name="dtos">Navigate集合</param>
        /// <returns></returns>
        public void Add(List<NavigateDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<NavigateDto>, IEnumerable<Navigate>>(dtos);
            entities.Each(x => repository.Insert(x));
        }

        /// <summary>
        /// 编辑Navigate
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(NavigateDto dto)
        {
            var entity = Mapper.Map<NavigateDto, Navigate>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新Navigate
        /// </summary>
        /// <param name="dtos">Navigate实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<NavigateDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<NavigateDto>, IEnumerable<Navigate>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除Navigate
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除Navigate
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<NavigateDto, bool>> exp)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        /// <summary>
        ///  获取单条符合条件的 Navigate 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public NavigateDto GetOne(Expression<Func<NavigateDto, bool>> exp)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Navigate, NavigateDto>(entity);

        }

        /// <summary>
        /// 查询符合调价的 Navigate
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<NavigateDto> Query<OrderKeyType>(Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            var order = orderExp.Cast<NavigateDto, Navigate, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Navigate>, List<NavigateDto>>(list);
        }

        /// <summary>
        /// 分页获取Navigate
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<NavigateDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            var order = orderExp.Cast<NavigateDto, Navigate, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<NavigateDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Navigate>, List<NavigateDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取Navigate
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<NavigateDto> GetWithPages(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            //var order = orderExp.Cast<NavigateDto, NavigateEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<NavigateDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Navigate>, List<NavigateDto>>(list)
            };
            return dto;

        }

        public NavigateDto Get()
        {
            return Mapper.Map<Navigate, NavigateDto>(repository.Table.FirstOrDefault());
        }
    }
}
