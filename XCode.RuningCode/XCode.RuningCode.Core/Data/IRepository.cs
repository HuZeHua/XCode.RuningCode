using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XCode.RuningCode.Core.Data
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        T GetOne(Expression<Func<T, bool>> exp);

        IQueryable<T> GetQuery<OrderKeyType>(Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> exp,
            string orderBy, string orderDir);

        IQueryable<T> GetQuery<IncludeKeyType, OrderKeyType>(Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true);

        IQueryable<T> GetQuery<IncludeKeyType>(Expression<Func<T, IncludeKeyType>> includeExp,
            Expression<Func<T, bool>> exp,
            string orderBy, string orderDir);

        void Insert(IEnumerable<T> entities);
    }
}
