using System.Web.Mvc;
using System.Web.Mvc.Html;
using XCode.RuningCode.Core.Infrastucture;
using XCode.RuningCode.Service.Abstracts;
using XCode.RuningCode.Service.Implements;

namespace XCode.RuningCode.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionPermissionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            string controllerName = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            return ActionPermissionLink(htmlHelper, linkText, controllerName + actionName);
        }

        public static MvcHtmlString ActionPermissionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string permissionName)
        {
            if (XCodeContainer.Resolve<IPermissionService>().Authorize(permissionName))
            {
                return htmlHelper.ActionLink(linkText, actionName);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString ActionPermissionLink(this HtmlHelper htmlHelper, string controllerName, string actionName,object routeValue)
        {
            
            if (XCodeContainer.Resolve<IPermissionService>().Authorize(""))
            {
                return htmlHelper.ActionLink(controllerName, actionName,routeValue);
            }
            return MvcHtmlString.Empty;
        }
    }
}