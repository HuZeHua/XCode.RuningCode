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
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Implements.Blog
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> repository;

        public ArticleService(IRepository<Article> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 添加Article
        /// </summary>
        /// <param name="dto">Article实体</param>
        /// <returns></returns>
        public void Add(ArticleDto dto)
        {
            var entity = Mapper.Map<ArticleDto, Article>(dto);
            repository.Insert(entity);
        }

        /// <summary>
        /// 批量添加Article
        /// </summary>
        /// <param name="dtos">Article集合</param>
        /// <returns></returns>
        public void Add(List<ArticleDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(dtos);
            entities.Each(x => repository.Insert(x));
        }

        /// <summary>
        /// 编辑Article
        /// </summary>
        /// <param name="dto">实体</param>
        /// <returns></returns>
        public void Update(ArticleDto dto)
        {
            var entity = Mapper.Map<ArticleDto, Article>(dto);
            repository.Update(entity);
        }

        /// <summary>
        /// 批量更新Article
        /// </summary>
        /// <param name="dtos">Article实体集合</param>
        /// <returns></returns>
        public void Update(IEnumerable<ArticleDto> dtos)
        {
            var entities = Mapper.Map<IEnumerable<ArticleDto>, IEnumerable<Article>>(dtos);
            entities.Each(x => repository.Update(x));
        }

        /// <summary>
        /// 删除Article
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var model = repository.GetById(id);
            repository.Delete(model);
        }

        /// <summary>
        /// 批量删除Article
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public void Delete(Expression<Func<ArticleDto, bool>> exp)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();

            var models = repository.Table.Where(where);
            repository.Delete(models);
        }

        /// <summary>
        ///  获取单条符合条件的 Article 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public ArticleDto GetOne(Expression<Func<ArticleDto, bool>> exp)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            var entity = repository.Table.AsNoTracking().FirstOrDefault(where);

            return Mapper.Map<Article, ArticleDto>(entity);

        }

        /// <summary>
        /// 查询符合调价的 Article
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<ArticleDto> Query<OrderKeyType>(Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            var order = orderExp.Cast<ArticleDto, Article, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);
            var list = query.ToList();
            return Mapper.Map<List<Article>, List<ArticleDto>>(list);
        }

        /// <summary>
        /// 分页获取Article
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<ArticleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            var order = orderExp.Cast<ArticleDto, Article, OrderKeyType>();
            var query = repository.GetQuery(where, order, isDesc);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<ArticleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Article>, List<ArticleDto>>(list)
            };
            return dto;
        }

        /// <summary>
        /// 分页获取Article
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<ArticleDto> GetWithPages(QueryBase queryBase, Expression<Func<ArticleDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            //var order = orderExp.Cast<ArticleDto, ArticleEntity, OrderKeyType>();
            var query = repository.GetQuery(where, orderBy, orderDir);

            var query_count = query.FutureCount();
            var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
            var list = query_list.ToList();

            var dto = new ResultDto<ArticleDto>
            {
                recordsTotal = query_count.Value,
                data = Mapper.Map<List<Article>, List<ArticleDto>>(list)
            };
            return dto;

        }

        public ArticleDto Get()
        {
            return Mapper.Map<Article, ArticleDto>(repository.Table.FirstOrDefault());
        }

        public ArticleDto get_by_id(int id)
        {
            return Mapper.Map<Article, ArticleDto>(repository.Table.FirstOrDefault(x => x.Id == id));
        }

        public void add_view(int id)
        {
            var entity = repository.GetById(id);
            entity.Views++;
            repository.Update(entity);
        }

        public List<ArticleDto> Query(Expression<Func<ArticleDto, bool>> exp)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            var entity = repository.Table.AsNoTracking().Where(where).ToList();

            return Mapper.Map<List<Article>, List<ArticleDto>>(entity);
        }

        public List<ArticleDto> get_article_by_tag(int value)
        {
            var article = repository.Table.Where(x => x.Tags.Select(y=>y.Id).Contains(value)).ToList();
            return Mapper.Map<List<Article>, List<ArticleDto>>(article);
        }

        public List<ArticleDto> Query<OrderKeyType>(Expression<Func<ArticleDto, bool>> exp, Expression<Func<ArticleDto, OrderKeyType>> orderExp, bool is_desc, int count)
        {
            var where = exp.Cast<ArticleDto, Article, bool>();
            var order = orderExp.Cast<ArticleDto, Article, OrderKeyType>();
            var query = repository.GetQuery(where, order, is_desc);
            var list = query.Take(count).ToList();
            return Mapper.Map<List<Article>, List<ArticleDto>>(list);
        }
    }
}
