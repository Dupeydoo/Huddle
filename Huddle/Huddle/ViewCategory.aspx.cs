using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Huddle.Data.Entities;
using Huddle.Data.ModelBinding;
using Huddle.Objects.Common;

namespace Huddle
{
    /*
     * The page where threads are under a certain category are viewed.
     * 
     * @author  James
     * @version 1.0.0
    */
    public partial class ViewCategory : BasePage
    {
        /*
         * The page load event for a page. Check the query string for a category id and ensure its valid.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       2.0.0
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqId = Request.QueryString["id"];
            if(reqId != null) 
            {
                try {
                    int id = Convert.ToInt32(reqId);
                    if(id <= HuddleCommon.CategoryCount && id > 0)
                    {
                        Page.Title = this.GetCategoryTitle(id);
                        // Pass the id to the control
                        Threads.CategoryId = id;
                    }   

                    else
                    {
                        SetDefaultOnError();
                    }
                }

                catch(System.FormatException)
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
         * A method to grab the category title based on its id.
         * 
         * @param    id  The category id
         * @author   James
         * @see      Huddle.Data.ModelBinding.CategoriesData
         * @returns  A string that contains the title
         * @version  1.0.0
        */
        private string GetCategoryTitle(int id)
        {
            return new CategoriesData().GetCategoryTitleFromDB(id);
        }

        /*
         * A helper method which sets error messages to the user on category viewing error.
         * 
         * @author   James
         * @version  1.0.0
        */
        private void SetDefaultOnError()
        {
            Page.Title = "View Category";
            ThreadsPanel.Visible = false;
            ErrorPanel.Visible = true;   
        }

    }
}