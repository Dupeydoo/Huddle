﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Huddle.Objects;
using Huddle.Data.ModelBinding;

namespace Huddle.Controls
{
    public partial class Posts : System.Web.UI.UserControl
    {
        private int PostNum = 1;
        private int PostsSelected;

        public int ThreadId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PostsSelected = 0;
        }

        public IEnumerable<Post> PostsView_GetData(int? maximumRows, int? startRowIndex, out int totalRowCount,
            string sortByExpression)
        {
            totalRowCount = 12; //DYNAMIC
            return new PostsData().GetPostsFromDB(ThreadId, this.PostsSelected);
        }

        protected void PostsView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal pNumber = (Literal)e.Item.FindControl("PostNumber");
            pNumber.Text = "#" + PostNum.ToString();
            this.PostNum++;
        }

        protected void PostsView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            PostsPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PostsView.DataBind();
        }

        
    }
}