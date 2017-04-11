using System.Web.Mvc;
using System.Web.Security;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Abstracts.Blog;
using XCode.RuningCode.Service.Dto.Blog;

namespace XCode.RuningCode.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IArticleService articleService;
        private readonly ITagService tagService;
        private readonly IAuthorizeProvider provider;

        public ArticleController(ICategoryService category_service, IArticleService article_service, ITagService tag_service, IAuthorizeProvider provider)
        {
            categoryService = category_service;
            articleService = article_service;
            tagService = tag_service;
            this.provider = provider;
        }

        public ActionResult Add()
        {
            ViewBag.ParentCategory = categoryService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View();
        }

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, ArticleDto dto)
        {
            var user = provider.GetAuthorizeUser();
            var tag = tagService.Get();
            var category = categoryService.GetCategoryById(1);
            dto.Category = category;
            dto.Author = user;
            dto.Tags.Add(tag);
            articleService.Add(dto);
            return RedirectToAction("Index", "Blog");
        }
    }
}