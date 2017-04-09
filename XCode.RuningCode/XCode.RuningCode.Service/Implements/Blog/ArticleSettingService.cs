using System;
using System.Linq;
using AutoMapper;
using XCode.RuningCode.Core.Data;
using XCode.RuningCode.Entity.Blog;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Implements.Blog
{
    public class ArticleSettingService : IArticleSettingService
    {
        private readonly IRepository<ArticleSetting> _repository;

        public ArticleSettingService(IRepository<ArticleSetting> repository)
        {
            this._repository = repository;
        }

        public ArticleSettingDto ArticleSetting()
        {
            return Mapper.Map<ArticleSetting, ArticleSettingDto>(_repository.Table.First());
        }

        public int GetArticlePageSize()
        {
            return ArticleSetting().ArticlePageSize;
        }

        public int GetCommentPageSize()
        {
            return ArticleSetting().CommentPageSize;
        }

        public int GetLatestCommentPageSize()
        {
            return ArticleSetting().LatestCommentPageSize;
        }

        public int GetHotCommentPageSize()
        {
            return ArticleSetting().HotCommentPageSize;
        }

        public int GetHotArticlePageSize()
        {
            return ArticleSetting().HotArticlePageSize;
        }

        public bool AllowComment()
        {
            return ArticleSetting().AllowComment;
        }

        public void Update(ArticleSettingDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("article");
            var entity = Mapper.Map<ArticleSettingDto, ArticleSetting>(dto);
            _repository.Update(entity);
        }
    }
}
