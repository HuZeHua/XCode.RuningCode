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

namespace XCode.RuningCode.Service.Abstracts
{
    /// <summary>
    /// RoleMenu业务契约
    /// </summary>
    public class RoleMenuService : IDependency, IRoleMenuService
    {
        private readonly IRepository<RoleMenu> repository;

        public RoleMenuService(IRepository<RoleMenu> repository)
        {
            this.repository = repository;
        }

        #region IRoleMenuService 接口实现

        /// <summary>
        /// 添加rolemenu
        /// </summary>
        /// <param name="dto">rolemenu实体</param>
        /// <returns></returns>
        public void Add(RoleMenuDto dto)
        {
            var entity = Mapper.Map<RoleMenuDto, RoleMenu>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加rolemenu
        /// </summary>
        /// <param name="dtos">rolemenu集合</param>
        /// <returns></returns>
        public void Add(List<RoleMenuDto> dtos)
        {
            var entities = Mapper.Map<List<RoleMenuDto>, List<RoleMenu>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑rolemenu
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(RoleMenuDto dto)
        {
            var entity = Mapper.Map<RoleMenuDto, RoleMenu>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新rolemenu
        /// </summary>
        /// <param name="dtos">rolemenu实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<RoleMenuDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<RoleMenuDto>, IEnumerable<RoleMenu>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除rolemenu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除rolemenu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<RoleMenuDto, bool>> exp)
        {
            var where = exp.Cast<RoleMenuDto, RoleMenu, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 rolemenu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public RoleMenuDto GetOne(Expression<Func<RoleMenuDto, bool>> exp)
        {
            var where = exp.Cast<RoleMenuDto, RoleMenu, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<RoleMenu, RoleMenuDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 rolemenu
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<RoleMenuDto> Query<OrderKeyType>(Expression<Func<RoleMenuDto, bool>> exp, Expression<Func<RoleMenuDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<RoleMenuDto, RoleMenu, bool>();
            var order = orderExp.Cast<RoleMenuDto, RoleMenu, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<RoleMenu>, List<RoleMenuDto>>(list);
        }

        /// <summary>
        /// 分页获取RoleMenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<RoleMenuDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenuDto, bool>> exp, Expression<Func<RoleMenuDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<RoleMenuDto, RoleMenu, bool>();
            var order = orderExp.Cast<RoleMenuDto, RoleMenu, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<RoleMenuDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<RoleMenu>, List<RoleMenuDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取RoleMenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<RoleMenuDto> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenuDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<RoleMenuDto, RoleMenu, bool>();
            //var order = orderExp.Cast<RoleMenuDto, RoleMenuEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<RoleMenuDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<RoleMenu>, List<RoleMenuDto>>(list)
            };
            return dto;
        }

        #endregion
    }
}
