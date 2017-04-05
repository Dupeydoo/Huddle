using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Huddle.Data.Entities;
using Huddle.Data.ModelBinding;

namespace Huddle
{
    public partial class ViewCategory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                try {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Page.Title = this.GetCategoryTitle(id);
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

        private string GetCategoryTitle(int id)
        {
            return new CategoriesData().GetCategoryTitleFromDB(id);
        }

        private void SetDefaultOnError()
        {
            Page.Title = "View Category";
            ThreadsPanel.Visible = false;
            ErrorPanel.Visible = true;
        }

    }
}