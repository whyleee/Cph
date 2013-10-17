using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cph.Aids;
using Cph.Data;

namespace Cph
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new DataCreator());

            ModelBinders.Binders.Add(typeof(DateTime), new FormattedDateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new FormattedDateTimeModelBinder());
        }
    }
}