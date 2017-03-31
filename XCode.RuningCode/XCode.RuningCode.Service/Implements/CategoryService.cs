using System;
using System.Collections.Generic;
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
    public class CategoryService : ICategoryService
    {

        private readonly IRepository<Category> repository;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public ResultDto<CategoryDto> GetWithPages(QueryBase queryBase, Expression<Func<CategoryDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<CategoryDto, Category, bool>();
            //var order = orderExp.Cast<MenuDto, MenuEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<CategoryDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Category>, List<CategoryDto>>(list)
            };
            return dto;
        }

        public virtual CategoryDto GetCategoryById(int id)
        {
            var category= id == 0 ? null : repository.GetById(id);
            return Mapper.Map<Category, CategoryDto>(category);
        }

        public virtual void InsertCategory(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException("category");
            var entity = Mapper.Map<CategoryDto, Category>(category);
            repository.Insert(entity);
        }


        public virtual void UpdateCategory(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var entity = Mapper.Map<CategoryDto, Category>(category);
            repository.Update(entity);
        }


        public virtual void DeleteCategory(CategoryDto category)
        {
            if (category == null)
                throw new ArgumentNullException("category");
            var entity = repository.GetById(category.Id);
            repository.Delete(entity);
        }

        public virtual string GetFormattedBreadCrumb(CategoryDto category, string separator = ">>")
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = string.Empty;

            var already_processed_category_ids = new List<int>();

            while (category != null && !category.IsDeleted &&
                !already_processed_category_ids.Contains(category.Id))
            {
                result = string.IsNullOrEmpty(result) ? category.Name : string.Format("{0} {1} {2}", category.Name, separator, result);
            }

            return result;
        }

        public void Delete(Expression<Func<CategoryDto, bool>> exp)
        {
            var where = exp.Cast<CategoryDto, Category, bool>();

            var models = repository.Table.Where(where);

            repository.Delete(models);

            models.Each(x => repository.Delete(x));
        }

        public List<CategoryDto> Query<OrderKeyType>(Expression<Func<CategoryDto, bool>> exp, Expression<Func<CategoryDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<CategoryDto, Category, bool>();
            var order = orderExp.Cast<CategoryDto, Category, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Category>, List<CategoryDto>>(list);
        }
    }
}
