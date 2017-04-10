using System.Web.Mvc;
using XCode.RuningCode.Service.Abstracts.Blog;

namespace XCode.RuningCode.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ITagService tagService;
        private IArticleService articleService;

        public BlogController(ICategoryService categoryService, ITagService tagService, IArticleService articleService)
        {
            this.categoryService = categoryService;
            this.tagService = tagService;
            this.articleService = articleService;
        }

        // GET: Blog
        public ActionResult Index()
        {
            ViewBag.Categories = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            ViewBag.Tags = tagService.Query(item => !item.IsDeleted, item => item.Id, false);
            ViewBag.Articles = articleService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View();
        }

        public ActionResult Detial()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}