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
    /// UserRole业务契约
    /// </summary>
    public class UserRoleService : IDependency, IUserRoleService
    {
        private IRepository<UserRole> repository;

        #region IUserRoleService 接口实现

        /// <summary>
        /// 添加userrole
        /// </summary>
        /// <param name="dto">userrole实体</param>
        /// <returns></returns>
        public void Add(UserRoleDto dto)
        {
            var entity = Mapper.Map<UserRoleDto, UserRole>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加userrole
        /// </summary>
        /// <param name="dtos">userrole集合</param>
        /// <returns></returns>
        public void Add(List<UserRoleDto> dtos)
        {
            var entities = Mapper.Map<List<UserRoleDto>, List<UserRole>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑userrole
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(UserRoleDto dto)
        {
            var entity = Mapper.Map<UserRoleDto, UserRole>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新userrole
        /// </summary>
        /// <param name="dtos">userrole实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<UserRoleDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<UserRoleDto>, IEnumerable<UserRole>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除userrole
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除userrole
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<UserRoleDto, bool>> exp)
        {
            var where = exp.Cast<UserRoleDto, UserRole, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 userrole 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public UserRoleDto GetOne(Expression<Func<UserRoleDto, bool>> exp)
        {
            var where = exp.Cast<UserRoleDto, UserRole, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<UserRole, UserRoleDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 userrole
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<UserRoleDto> Query<OrderKeyType>(Expression<Func<UserRoleDto, bool>> exp, Expression<Func<UserRoleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserRoleDto, UserRole, bool>();
            var order = orderExp.Cast<UserRoleDto, UserRole, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<UserRole>, List<UserRoleDto>>(list);
        }

        /// <summary>
        /// 分页获取UserRole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<UserRoleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserRoleDto, bool>> exp, Expression<Func<UserRoleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserRoleDto, UserRole, bool>();
            var order = orderExp.Cast<UserRoleDto, UserRole, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserRoleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<UserRole>, List<UserRoleDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取UserRole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<UserRoleDto> GetWithPages(QueryBase queryBase, Expression<Func<UserRoleDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<UserRoleDto, UserRole, bool>();
            //var order = orderExp.Cast<UserRoleDto, UserRoleEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserRoleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<UserRole>, List<UserRoleDto>>(list)
            };
            return dto;
        }

        #endregion
    }
}
