﻿using Huddle.Data.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Huddle
{
    public partial class ViewThread : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Page.Title = this.GetThreadTitleFromDB(id);
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

        private string GetThreadTitleFromDB(int id)
        {
            return new ThreadsData().GetThreadTitleFromDB(id);
        }

        private void SetDefaultOnError()
        {
            Page.Title = "View Thread";
            PostsPanel.Visible = false;
            ErrorPanel.Visible = true;
        }
    }
}