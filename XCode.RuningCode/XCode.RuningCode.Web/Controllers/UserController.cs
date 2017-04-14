using System.Web.Mvc;
using XCode.RuningCode.Core.Extentions;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthorizeProvider provider;

        public UserController(IUserService userService, IAuthorizeProvider provider)
        {
            this.userService = userService;
            this.provider = provider;
        }

        [HttpGet, AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult SignIn(SignInDto model)
        {
            provider.SignIn(model);
            if (userService.SignIn(model.UserName, model.Password.ToMD5()))
            {
                provider.SignIn(model);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "无效的用户名或密码");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                provider.SignOut();
            }
            return RedirectToAction("SignIn");
        }

        [AllowAnonymous]
        public ActionResult ForgotPwd()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Reg()
        {
            return View();
        }
    }
}