using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IArticleService articleService;

        public BlogController(ICategoryService categoryService, ITagService tagService, IArticleService articleService)
        {
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.articleService = articleService;
        }

        public ActionResult Index(ArticleQueryType? type, int? id)
        {
            ViewBag.Categories = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            var articleDtos = new List<ArticleDto>();
            if (type == null || type == ArticleQueryType.Article || id == null)
            {
                articleDtos = articleService.Query(item => !item.IsDeleted, item => item.Id, false);
            }
            else if (type == ArticleQueryType.Category)
            {
                articleDtos = articleService.Query(x => x.Category.Id == id);
            }
            else if (type == ArticleQueryType.Tag)
            {
                articleDtos = articleService.Query(t => t.Tags.Select(m => m.Id).Contains(id.Value));
            }

            ViewBag.Tags = tagService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View(articleDtos);
        }

        public ActionResult Detial(int id)
        {
            articleService.add_view(id);
            var article = articleService.get_by_id(id);
            return View(article);
        }

        [ChildActionOnly]
        public ActionResult AuthorInfo()
        {
            return View("_AuthorInfo");
        }

        [ChildActionOnly]
        public ActionResult TagList()
        {
            var tags = tagService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View("_TagList", tags);
        }

        [ChildActionOnly]
        public ActionResult HotArticle()
        {
            var articleDtos = articleService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View("_HotArticle", articleDtos);
        }

        [ChildActionOnly]
        public ActionResult FriendLinkList()
        {
            return View("_FriendLinkList");
        }
    }
}