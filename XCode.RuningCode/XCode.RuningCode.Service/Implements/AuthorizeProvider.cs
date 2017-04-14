using System;
using System.Web;
using System.Web.Security;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;

namespace XCode.RuningCode.Service.Implements
{
    public class AuthorizeProvider : IAuthorizeProvider
    {
        private readonly IUserService userService;

        public AuthorizeProvider(IUserService userService)
        {
            this.userService = userService;
        }

        public UserDto GetAuthorizeUser()
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null || !httpContext.Request.IsAuthenticated ||
                (!(httpContext.User.Identity is FormsIdentity))) return null;
            var formIdentity = (FormsIdentity)httpContext.User.Identity;
            var userName = formIdentity.Ticket.Name;
            var userData = formIdentity.Ticket.UserData;
            return !string.IsNullOrWhiteSpace(userName) ? userService.get_by_name(userName) : null;
        }

        public void SignIn(UserDto user, bool rememberMe)
        {
            var userData = Guid.NewGuid().ToString();
            var ticket = new FormsAuthenticationTicket(1, user.LoginName, DateTime.Now, DateTime.Now.AddMinutes(15), rememberMe, userData);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket) { HttpOnly = true };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}