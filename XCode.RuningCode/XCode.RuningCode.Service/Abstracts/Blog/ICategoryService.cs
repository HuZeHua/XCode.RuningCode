using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface ICategoryService
    {

        ResultDto<CategoryDto> GetWithPages(QueryBase queryBase, Expression<Func<CategoryDto, bool>> exp, string orderBy, string orderDir = "desc");

        CategoryDto GetCategoryById(int id);


        void InsertCategory(CategoryDto category);


        void UpdateCategory(CategoryDto category);


        void DeleteCategory(CategoryDto category);


        string GetFormattedBreadCrumb(CategoryDto category, string separator = ">>");
        void Delete(Expression<Func<CategoryDto, bool>> exp);

        List<CategoryDto> Query<OrderKeyType>(Expression<Func<CategoryDto, bool>> exp,
            Expression<Func<CategoryDto, OrderKeyType>> orderExp, bool isDesc = true);
    }
}
