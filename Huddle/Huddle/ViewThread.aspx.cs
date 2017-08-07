using Huddle.Data.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Huddle
{
    /*
     * The page where posts under a certain thread are viewed.
     * 
     * @author  James
     * @version 1.0.0
    */
    public partial class ViewThread : BasePage
    {
        /*
         * The page load event for a page. Check the query string for a thread id and ensure its valid.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    // Need the title for page
                    Page.Title = this.GetThreadTitleFromDB(id);
                    // Pass the id to the control
                    Posts.ThreadId = id;
                }

                catch (System.FormatException)
                {
                    SetDefaultOnError();
                }
            }

            else
            {
                SetDefaultOnError();
            }
        }

        /*
         * A method to grab the thread title based on its id.
         * 
         * @param    id  The thread id
         * @author   James
         * @see      Huddle.Data.ModelBinding.ThreadsData
         * @returns  A string that contains the title
         * @version  1.0.0
        */
        private string GetThreadTitleFromDB(int id)
        {
            return new ThreadsData().GetThreadTitleFromDB(id);
        }

        /*
         * A helper method which sets error messages to the user on category viewing error.
         * 
         * @author   James
         * @version  1.0.0
        */
        private void SetDefaultOnError()
        {
            Page.Title = "View Thread";
            PostsPanel.Visible = false;
            ErrorPanel.Visible = true;
        }
    }
}