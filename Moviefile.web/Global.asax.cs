using Moviefile.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Moviefile.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<MoviefileContext>(new MigrateDatabaseToLatestVersion<MoviefileContext, Moviefile.data.Migrations.Configuration>());
            new MoviefileContext().Database.Initialize(false);
        }
    }
}
