﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal;
using EntityFramework.Extensions;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Implements.Blog
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> repository;

        public TagService(IRepository<Tag> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加tag
        /// </summary>
        /// <param name="dto">tag实体</param>
        /// <returns></returns>
        public void Add(TagDto dto)
        {
            var entity = Mapper.Map<TagDto, Tag>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加tag
        /// </summary>
        /// <param name="dtos">tag集合</param>
        /// <returns></returns>
        public void Add(List<TagDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<TagDto>, IEnumerable<Tag>>(dtos);
            entities.Each(x => repository.Insert(x));
        }

        /// <summary>
        /// 编辑tag
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(TagDto dto)
        {
            var entity = Mapper.Map<TagDto, Tag>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新tag
        /// </summary>
        /// <param name="dtos">tag实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<TagDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<TagDto>, IEnumerable<Tag>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除tag
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除tag
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<TagDto, bool>> exp)
        {
            var where = exp.Cast<TagDto, Tag, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        /// <summary>
        ///  获取单条符合条件的 tag 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public TagDto GetOne(Expression<Func<TagDto, bool>> exp)
        {
            var where = exp.Cast<TagDto, Tag, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Tag, TagDto>(entity);

        }

        /// <summary>
        /// 查询符合调价的 tag
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<TagDto> Query<OrderKeyType>(Expression<Func<TagDto, bool>> exp, Expression<Func<TagDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<TagDto, Tag, bool>();
            var order = orderExp.Cast<TagDto, Tag, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Tag>, List<TagDto>>(list);
        }

        /// <summary>
        /// 分页获取tag
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<TagDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<TagDto, bool>> exp, Expression<Func<TagDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<TagDto, Tag, bool>();
            var order = orderExp.Cast<TagDto, Tag, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<TagDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Tag>, List<TagDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取tag
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<TagDto> GetWithPages(QueryBase queryBase, Expression<Func<TagDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<TagDto, Tag, bool>();
            //var order = orderExp.Cast<TagDto, tagEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<TagDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Tag>, List<TagDto>>(list)
            };
            return dto;

        }

        public TagDto Get()
        {
            return Mapper.Map<Tag, TagDto>(repository.Table.FirstOrDefault());
        }
    }
}
