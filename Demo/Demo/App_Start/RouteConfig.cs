using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Appointment",
                "Appointment/{action}/{patientId}/{startDate}/{endDate}",
                new { controller = "Appointment", action = "Select", patientId = 1, startDate = "01/01/1999", endDate = "03/03/2022" }
            );
        }
    }
}
