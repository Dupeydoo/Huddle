using System;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using Huddle.Data.Misc;
using Huddle.Objects.Common;

namespace Huddle
{
    /*
     * A class to manage global application events.
     * 
     * @author  James
     * @version 1.0.0
    */
    public class Global : System.Web.HttpApplication
    {
        /*
         * The event that runs on app start. Bundles and routes are registered.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0 
        */
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.1.1.min.js"
                }
            );

            this.RegisterCategoryCount();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        /*
         * This method sets up the category count on startup. This allows us
         * to check if an invalid category is input when a category is viewed.
         * This should only happen when cheeky people who know how urls work 
         * mess around.
         * 
         * @author   James
         * @version  1.0.0
        */
        private void RegisterCategoryCount()
        {
            int cc = new MiscData().GetCategoryCount();
            HuddleCommon.CategoryCount = cc;
        }
    }
}