using System;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface ICategoryService
    {

        ResultDto<CategoryDto> GetWithPages(QueryBase queryBase, Expression<Func<CategoryDto, bool>> exp, string orderBy, string orderDir = "desc");

        CategoryDto GetCategoryById(int id);


        void InsertCategory(CategoryDto category);


        void UpdateCategory(CategoryDto category);


        void DeleteCategory(CategoryDto category);


        string GetFormattedBreadCrumb(CategoryDto category, string separator = ">>");
    }
}
