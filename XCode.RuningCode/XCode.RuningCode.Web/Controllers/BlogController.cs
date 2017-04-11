using System.Web.Mvc;
using XCode.RuningCode.Service.Abstracts.Blog;

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

        public ActionResult Index()
        {
            ViewBag.Categories = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            ViewBag.Tags = tagService.Query(item => !item.IsDeleted, item => item.Id, false);
            ViewBag.Articles = articleService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View();
        }

        public ActionResult Detial(int id)
        {
            articleService.add_view(id);
            var article = articleService.get_by_id(id);
            return View(article);
        }
    }
}