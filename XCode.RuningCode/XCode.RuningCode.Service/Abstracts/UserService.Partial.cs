using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal;
using EntityFramework.Extensions;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Data;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    /// <summary>
    /// User业务契约
    /// </summary>
    public partial class UserService : IDependency, IUserService
    {
        private IRepository<User> repository;
        private IRepository<UserRole> userRoleRepository;
        private IRepository<Role> rolelRepository;

        #region IUserService 接口实现

        public UserService()
        {
            this.repository = new EfRepository<User>(new XCodeContext());
            this.userRoleRepository = new EfRepository<UserRole>(new XCodeContext());
            this.rolelRepository = new EfRepository<Role>(new XCodeContext());
        }

        /// <summary>
        /// 添加user
        /// </summary>
        /// <param name="dto">user实体</param>
        /// <returns></returns>
        public void Add(UserDto dto)
        {
            var entity = Mapper.Map<UserDto, User>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加user
        /// </summary>
        /// <param name="dtos">user集合</param>
        /// <returns></returns>
        public void Add(List<UserDto> dtos)
        {
            var entities = Mapper.Map<List<UserDto>, List<User>>(dtos);
            repository.Insert(entities);
        }

        /// <summary>
        /// 编辑user
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(UserDto dto)
        {
            var entity = Mapper.Map<UserDto, User>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新user
        /// </summary>
        /// <param name="dtos">user实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<UserDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>(dtos);
            entities.Each(x => repository.Update(x));

        }

        /// <summary>
        /// 删除user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除user
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<UserDto, bool>> exp)
        {
            var where = exp.Cast<UserDto, User, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 user 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public UserDto GetOne(Expression<Func<UserDto, bool>> exp)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var entity = repository.GetOne(where);
            return Mapper.Map<User, UserDto>(entity);
        }

        /// <summary>
        /// 查询符合调价的 user
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<UserDto> Query<OrderKeyType>(Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var order = orderExp.Cast<UserDto, User, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<User>, List<UserDto>>(list);
        }

        /// <summary>
        /// 分页获取User
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<UserDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, Expression<Func<UserDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<UserDto, User, bool>();
            var order = orderExp.Cast<UserDto, User, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<User>, List<UserDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取User
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<UserDto> GetWithPages(QueryBase queryBase, Expression<Func<UserDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<UserDto, User, bool>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<UserDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<User>, List<UserDto>>(list)
            };
            return dto;
        }

        #endregion
    }
}
