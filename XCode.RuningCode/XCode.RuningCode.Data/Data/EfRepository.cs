using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Core.Extentions;

namespace XCode.RuningCode.Data.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext dbContext;

        private IDbSet<T> dbSet;

        protected virtual IDbSet<T> DbSet
        {
            get
            {
                this.dbSet = dbContext.Set<T>();
                return this.dbSet;
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.DbSet;
            }
        }

        public EfRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.DbSet.Add(entity);
            this.dbContext.SaveChanges();

        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.dbContext.SaveChanges();
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="OrderKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<OrderKeyType>(Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var query = DbSet.AsNoTracking().OrderByDescending(orderExp).Where(exp);
            if (!isDesc)
                query = DbSet.AsNoTracking().OrderBy(orderExp).Where(exp);
            return query;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="exp"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery(Expression<Func<T, bool>> exp,
            string orderBy, string orderDir)
        {
            var query = DbSet.AsNoTracking().OrderBy(orderBy, orderDir).Where(exp);
            return query;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="OrderKeyType"></typeparam>
        /// <typeparam name="IncludeKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="includeExp"></param>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<IncludeKeyType, OrderKeyType>(Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var query = DbSet.AsNoTracking().Include(includeExp).OrderByDescending(orderExp).Where(exp);
            if (!isDesc)
                query = DbSet.AsNoTracking().Include(includeExp).OrderBy(orderExp).Where(exp);
            return query;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="IncludeKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="includeExp"></param>
        /// <param name="exp"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<IncludeKeyType>(Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            string orderBy, string orderDir)
        {
            var query = DbSet.AsNoTracking().Include(includeExp).OrderBy(orderBy, orderDir).Where(exp);
            return query;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.DbSet.Add(entity);
            }
            this.dbContext.SaveChanges();
        }

        public T GetOne(Expression<Func<T, bool>> exp)
        {
            return DbSet.AsNoTracking().FirstOrDefault(exp);
        }
    }
}
