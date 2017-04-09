using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Service.Abstracts.Blog
{
    public interface IArticleSettingService
    {
        ArticleSettingDto ArticleSetting();
        int GetArticlePageSize();
        int GetCommentPageSize();
        int GetLatestCommentPageSize();
        int GetHotCommentPageSize();
        int GetHotArticlePageSize();
        bool AllowComment();
        void Update(ArticleSettingDto entity);
    }
}
