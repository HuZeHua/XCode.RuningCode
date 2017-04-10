using System.Web.Mvc;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Web.Controllers
{
    public class ArticleController : Controller
    {
        private ICategoryService categoryService;
        private IArticleService articleService;
        private ITagService tagService;

        public ArticleController(ICategoryService categoryService, IArticleService articleService, ITagService tagService)
        {
            this.categoryService = categoryService;
            this.articleService = articleService;
            this.tagService = tagService;
        }

        public ActionResult Add()
        {
            ViewBag.ParentCategory = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View();
        }

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, ArticleDto dto)
        {
            articleService.Add(dto);
            return RedirectToAction("Index", "Blog");
        }
    }
}