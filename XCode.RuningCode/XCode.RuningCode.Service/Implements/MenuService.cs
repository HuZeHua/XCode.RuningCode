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
    /// Menu业务契约
    /// </summary>
    public class MenuService : IDependency, IMenuService
    {
        private readonly IRepository<Menu> repository;

        public MenuService(IRepository<Menu> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加menu
        /// </summary>
        /// <param name="dto">menu实体</param>
        /// <returns></returns>
        public void Add(MenuDto dto)
        {
            var entity = Mapper.Map<MenuDto, Menu>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加menu
        /// </summary>
        /// <param name="dtos">menu集合</param>
        /// <returns></returns>
        public void Add(List<MenuDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<MenuDto>, IEnumerable<Menu>>(dtos);
            entities.Each(x => repository.Insert(x));
        }

        /// <summary>
        /// 编辑menu
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(MenuDto dto)
        {
            var entity = Mapper.Map<MenuDto, Menu>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新menu
        /// </summary>
        /// <param name="dtos">menu实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<MenuDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<MenuDto>, IEnumerable<Menu>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除menu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除menu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<MenuDto, bool>> exp)
        {
            var where = exp.Cast<MenuDto, Menu, bool>();

            var models = repository.Table.Where(where);
            models.Each(x => repository.Delete(x));
        }

        /// <summary>
        ///  获取单条符合条件的 menu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public MenuDto GetOne(Expression<Func<MenuDto, bool>> exp)
        {
            var where = exp.Cast<MenuDto, Menu, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Menu, MenuDto>(entity);

        }

        /// <summary>
        /// 查询符合调价的 menu
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<MenuDto> Query<OrderKeyType>(Expression<Func<MenuDto, bool>> exp, Expression<Func<MenuDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<MenuDto, Menu, bool>();
            var order = orderExp.Cast<MenuDto, Menu, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Menu>, List<MenuDto>>(list);
        }

        /// <summary>
        /// 分页获取Menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<MenuDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<MenuDto, bool>> exp, Expression<Func<MenuDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<MenuDto, Menu, bool>();
            var order = orderExp.Cast<MenuDto, Menu, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<MenuDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Menu>, List<MenuDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取Menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<MenuDto> GetWithPages(QueryBase queryBase, Expression<Func<MenuDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<MenuDto, Menu, bool>();
            //var order = orderExp.Cast<MenuDto, MenuEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<MenuDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Menu>, List<MenuDto>>(list)
            };
            return dto;

        }

        public MenuDto Get()
        {
            return Mapper.Map<Menu, MenuDto>(repository.Table.FirstOrDefault());
        }
    }
}
