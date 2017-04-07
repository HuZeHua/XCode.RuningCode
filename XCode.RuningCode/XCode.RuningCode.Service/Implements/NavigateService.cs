using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal;
using EntityFramework.Extensions;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Entity;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    public class NavigateService : INavigateService
    {
        private readonly IRepository<Navigate> repository;

        public NavigateService(IRepository<Navigate> repository)
        {
            this.repository = repository;
        }

        public void Add(NavigateDto navigate)
        {
            var entity = Mapper.Map<NavigateDto, Navigate>(navigate);
            if (repository.GetOne(x => x.Name == navigate.Name) != null)
            {
                repository.Insert(entity);
            }
        }

        public void Add(List<NavigateDto> models)
        {
            var entities = Mapper.Map<IEnumerable<NavigateDto>, IEnumerable<Navigate>>(models);
            entities.Each(x => repository.Insert(x));
        }

        public void Update(NavigateDto navigate)
        {
            var entity = Mapper.Map<NavigateDto, Navigate>(navigate);
            repository.Update(entity);
        }

        public void Update(IEnumerable<NavigateDto> navigates)
        {
            var entities = Mapper.Map<IEnumerable<NavigateDto>, IEnumerable<Navigate>>(navigates);
            entities.Each(x => repository.Update(x));
        }

        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        public void Delete(Expression<Func<NavigateDto, bool>> exp)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        public NavigateDto GetOne(Expression<Func<NavigateDto, bool>> exp)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Navigate, NavigateDto>(entity);
        }

        public List<NavigateDto> Query<OrderKeyType>(Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
            var order = orderExp.Cast<NavigateDto, Navigate, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Navigate>, List<NavigateDto>>(list);
        }

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

        public ResultDto<NavigateDto> GetWithPages(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<NavigateDto, Navigate, bool>();
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

        public NavigateDto get_by_name(string navigateName)
        {
            return Mapper.Map<Navigate, NavigateDto>(repository.Table.FirstOrDefault(x => x.Name == navigateName));
        }

        public void add_children_nav(NavigateDto parentDto, NavigateDto navigate_dto)
        {
            var parent = repository.GetOne(x => x.Name == parentDto.Name);
            var children = Mapper.Map<NavigateDto, Navigate>(navigate_dto);
            parent.add_children_nav(children);
            repository.Insert(children);
            repository.Update(parent);
        }
    }
}
