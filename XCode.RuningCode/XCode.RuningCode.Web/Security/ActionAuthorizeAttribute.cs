using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Autofac;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;

namespace XCode.RuningCode.Web.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class ActionAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly IPermissionService permissionService;

        public string[] PermissionNames { get; private set; }
        public ActionAuthorizeAttribute(string[] permissionNames)
        {
            permissionService=XCodeContainer.Current.Resolve<IPermissionService>();
            PermissionNames = permissionNames ?? new string[0];
        }

        public ActionAuthorizeAttribute()
        {
            permissionService = XCodeContainer.Current.Resolve<IPermissionService>();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;;
            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            var actionName = filterContext.ActionDescriptor.ActionName;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var actionPermissionNames = PermissionNames.ToList();
            actionPermissionNames.Add(controllerName + actionName);

            if (actionPermissionNames.Any(pName => permissionService.Authorize(pName)))
            {
                return;
            }

            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}