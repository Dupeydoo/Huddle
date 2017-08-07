using System;
using System.Collections.Generic;
using System.Web;

namespace Huddle
{
    /*
     A base page for all pages in the Huddle universe. Expect default page behaviour default
     to all pages

     @version 1.1.0
     */
    public class BasePage : System.Web.UI.Page
    {
        /*
         * The prerender event for a page. This function is more of a failsafe to ensure I give 
         * all my pages a title.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        private void Page_PreRender(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Title) || this.Title.Equals("Untitled Page", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Page title cannot be \"Untitled Page\" or an empty string.");
            }
        }

        /*
         * The preinit event for a page. Here we select the users preferred theme from a cookie and
         * ensure it can be chosen.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        private void Page_PreInit(object sender, EventArgs e)
        {
            // Get the theme from the registered request cookies
            HttpCookie preferredTheme = Request.Cookies.Get("PrefTheme");
            if (preferredTheme != null)
            {
                string folder = Server.MapPath("~/App_Themes/" + preferredTheme.Value);
                // If we can find the corresponding theme folder
                if (System.IO.Directory.Exists(folder))
                {
                    Page.Theme = preferredTheme.Value;
                }
            }
        }

        /*
         * Constructor to register the events of the page
         * 
         * @author James
         * @version 1.1.0
        */
        public BasePage()
        {
            this.PreRender += Page_PreRender;
            this.PreInit += Page_PreInit;
        }
    }
}