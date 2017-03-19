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
    /// Role业务契约
    /// </summary>
    public class RoleService : IDependency, IRoleService
    {
        private IRepository<Role> repository;

        #region IRoleService 接口实现

        public RoleService(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加role
        /// </summary>
        /// <param name="dto">role实体</param>
        /// <returns></returns>
        public void Add(RoleDto dto)
        {
            var entity = Mapper.Map<RoleDto, Role>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加role
        /// </summary>
        /// <param name="dtos">role集合</param>
        /// <returns></returns>
        public void Add(List<RoleDto> dtos)
        {
            var entities = Mapper.Map<List<RoleDto>, List<Role>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑role
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(RoleDto dto)
        {
            var entity = Mapper.Map<RoleDto, Role>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新role
        /// </summary>
        /// <param name="dtos">role实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<RoleDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<RoleDto>, IEnumerable<Role>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除role
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除role
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<RoleDto, bool>> exp)
        {
            var where = exp.Cast<RoleDto, Role, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 role 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public RoleDto GetOne(Expression<Func<RoleDto, bool>> exp)
        {
            var where = exp.Cast<RoleDto, Role, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Role, RoleDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 role
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<RoleDto> Query<OrderKeyType>(Expression<Func<RoleDto, bool>> exp, Expression<Func<RoleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<RoleDto, Role, bool>();
            var order = orderExp.Cast<RoleDto, Role, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Role>, List<RoleDto>>(list);
        }

        /// <summary>
        /// 分页获取Role
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleDto, bool>> exp, Expression<Func<RoleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {

            var where = exp.Cast<RoleDto, Role, bool>();
            var order = orderExp.Cast<RoleDto, Role, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<RoleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Role>, List<RoleDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取Role
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetWithPages(QueryBase queryBase, Expression<Func<RoleDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<RoleDto, Role, bool>();
            //var order = orderExp.Cast<RoleDto, RoleEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<RoleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Role>, List<RoleDto>>(list)
            };
            return dto;
        }

        #endregion
    }
}
