using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Web.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private readonly IArticleService articleService;
        private readonly IFriendlyLinkService friendly_link_service;

        public BlogController(ICategoryService category_service, ITagService tag_service, IArticleService article_service, IFriendlyLinkService friendly_link_service)
        {
            categoryService = category_service;
            tagService = tag_service;
            articleService = article_service;
            this.friendly_link_service = friendly_link_service;
        }

        public ActionResult Index(ArticleQueryType? type, int? id)
        {
            ViewBag.Categories = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            var articleDtos = new List<ArticleDto>();
            if (type == null || type == ArticleQueryType.Article || id == null)
            {
                articleDtos = articleService.Query(item => !item.IsDeleted, item => item.CreateDateTime);
            }
            else if (type == ArticleQueryType.Category)
            {
                articleDtos = articleService.Query(x => x.Category.Id == id && !x.IsDeleted, x => x.CreateDateTime);
            }
            else if (type == ArticleQueryType.Tag)
            {
                articleDtos = articleService.get_article_by_tag(id.Value);
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
            var articleDtos = articleService.Query(x => !x.IsDeleted, y => y.Views, true, 5);
            return View("_HotArticle", articleDtos);
        }

        [ChildActionOnly]
        public ActionResult FriendLinkList()
        {
            var dtos = friendly_link_service.QueryAll();
            return View("_FriendLinkList", dtos);
        }

        [ChildActionOnly]
        public ActionResult Carousel()
        {
            //文章需要加入图片
            //var dtos = friendly_link_service.QueryAll();
            return View("_Carousel");
        }

        [ChildActionOnly]
        public ActionResult Recommend()
        {
            var articleDto = articleService.Query(x => !x.IsDeleted, y => y.Views, true, 1).FirstOrDefault();
            return View("_Recommend", articleDto);
        }
    }
}