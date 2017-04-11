using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Microsoft.Ajax.Utilities;
using XCode.RuningCode.Core;
using XCode.RuningCode.Core.Enums;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Core.Log;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Dto;
using XCode.RuningCode.Service.Enum;

namespace XCode.RuningCode.Web.Areas.Adm.Controllers
{
    /// <summary>
    /// AdmBase
    /// </summary>
    public class AdmBaseController : Controller
    {
        private readonly IPageViewService pageViewService;

        private readonly IUserService userService;

        private readonly IAuthorizeProvider provider;

        public AdmBaseController()
        {
            this.pageViewService = XCodeContainer.Current.Resolve<IPageViewService>();
            this.userService = XCodeContainer.Current.Resolve<IUserService>();
            this.provider = XCodeContainer.Current.Resolve<IAuthorizeProvider>();
        }
        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected UserDto CurrentUser { get; private set; }

        /// <summary>
        /// 是否登录
        /// </summary>
        protected bool IsLogined { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO
            //用户信息处理
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = provider.GetAuthorizeUser();
            }

            IsLogined = CurrentUser != null && CurrentUser.Id > 0;

            ViewRecord(requestContext);
        }

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="_context"></param>
        void ViewRecord(RequestContext _context)
        {
            try
            {
                var dto = new PageViewDto
                {
                    UserId = IsLogined ? CurrentUser.Id : 0,
                    LoginName = IsLogined ? CurrentUser.LoginName : string.Empty,
                    Url = _context.HttpContext.Request.Url.PathAndQuery.ToLower(),
                    IP = WebHelper.GetClientIP()
                };
                pageViewService.Add(dto);
            }
            catch (Exception ex)
            {
                Logger.Log("访问记录", ex);
            }
        }

        /// <summary>
        /// 获取指定菜单下的按钮
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetButtons(int parentId)
        {
            //获取我的角色
            var userId = CurrentUser.Id;
            var my_navigates = userService.GetMyNavigates(userId).DistinctBy(x=>x.Name);

            ViewBag.MyButtons = my_navigates.Where(item => item.Parent != null && item.Parent.Id == parentId && item.Type == MenuType.ButtonType)
                .OrderBy(item => item.SoreOrder)
                .ToList();
        }
    }
}