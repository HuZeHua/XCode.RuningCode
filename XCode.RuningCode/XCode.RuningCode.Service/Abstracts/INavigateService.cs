using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Abstracts
{
    public interface INavigateService
    {
       
		void Add(NavigateDto navigate);

        void Add(List<NavigateDto> models);

       
        void Update(NavigateDto navigate);

       
        void Update(IEnumerable<NavigateDto> navigates);

        
        void Delete(int id);

       
        void Delete(Expression<Func<NavigateDto, bool>> exp);


        NavigateDto GetOne(Expression<Func<NavigateDto, bool>> exp);

        
        List<NavigateDto> Query<OrderKeyType>(Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true);

       
        ResultDto<NavigateDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, Expression<Func<NavigateDto, OrderKeyType>> orderExp, bool isDesc = true);

       
        ResultDto<NavigateDto> GetWithPages(QueryBase queryBase, Expression<Func<NavigateDto, bool>> exp, string orderBy, string orderDir = "desc");
        
        NavigateDto get_by_name(string navigateName);
        void add_children_nav(NavigateDto parent, NavigateDto navigate_dto);
    }
}
