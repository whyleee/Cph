using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Cph.Data;
using JetBrains.Annotations;

namespace Cph.Aids
{
    public static class MvcExtensions
    {
        public static IHtmlString MenuLink(this HtmlHelper html, string linkText, [AspMvcAction] string actionName, [AspMvcController] string controllerName)
        {
            var currentAction = html.ViewContext.RouteData.GetRequiredString("action");
            var currentController = html.ViewContext.RouteData.GetRequiredString("controller");
            var active = actionName == currentAction && controllerName == currentController;
            
            return html.ActionLink(linkText, actionName, controllerName, null, active ? new {@class = "active"} : null);
        }

        public static string ToSocialIconClass(this SocialService service)
        {
            var serviceName = service.Name.ToLower();
            if (serviceName == "google") serviceName = "google-plus";
            return "icon-" + serviceName + "-sign";
        }
    }
}