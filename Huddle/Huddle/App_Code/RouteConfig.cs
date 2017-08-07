using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Huddle
{
    /*
     * A static class to provide all address routing management to the 
     * application
     * 
     * @author  James
     * @version 1.0.0
    */
    public static class RouteConfig
    {
        /*
         * A method to register the routing config
         * 
         * @param   routes  The collection maintaining the site routes
         * @author  James
         * @version 1.0.0
        */
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            // Use extensionless url's
            routes.EnableFriendlyUrls(settings);
        }
    }
}
