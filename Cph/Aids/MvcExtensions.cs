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
        public static IHtmlString MenuItem(this HtmlHelper html, string linkText, [AspMvcAction] string actionName, [AspMvcController] string controllerName)
        {
            var currentAction = html.ViewContext.RouteData.GetRequiredString("action");
            var currentController = html.ViewContext.RouteData.GetRequiredString("controller");
            var active = /*actionName == currentAction &&*/ controllerName == currentController;

            var li = active ? "<li class=\"active\">" : "<li>";
            return new HtmlString(li + html.ActionLink(linkText, actionName, controllerName) + "</li>");
        }

        public static string ToSocialIconClass(this SocialService service)
        {
            var serviceName = service.Name.ToLower();
            if (serviceName == "google") serviceName = "google-plus";
            if (serviceName == "stackoverflow") return "icon-stackexchange";
            return "icon-" + serviceName + "-sign";
        }
    }
}