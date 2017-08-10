using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Huddle.Objects;
using Huddle.Objects.Common;
using Huddle.Data.ModelBinding;
using Huddle.Enums;

namespace Huddle.Controls
{
    /*
     * The posts control providing the repeated format of posts
     * when viewing a thread.
     * 
     * @author  James
     * @version 1.3.2
    */
    public partial class Posts : System.Web.UI.UserControl
    {
        private int PostNum = 1;             // A local counter used to present a numerating of posts to the user
        private int PostsSelected;           // A figure to allow any number of posts to be skipped on the next page transition
        private int RowCount;                // Provides the mechanism to dynamically expand the totalRowCount. This is needed to display pages in the Pager

        public int ThreadId { get; set; }   // The thread id is passed via the control attributes to allow us to select the correct data

        /*
         * The page load event. Here we intialise the amount of posts we skip.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Intitialise the row count to a single standard page buffer length
            this.RowCount = (int)PagingEnum.PagerBuffer;
            this.PostsSelected = 0;
        }

        /*
         * The method which selects the posts in the given thread for display.
         * 
         * @param maximumRows      The maximum rows displayed at one time
         * @param starRowIndex     A counter which keeps track of the current data pages start
         * @param totalRowCount    The total amount of rows selected
         * @param sortByExpression An expression to sort data by
         * @see                    Huddle.Data.ModelBinding.PostsData
         * @returns                An IEnumerable of non ef wrapped post objects
         * @author                 James
         * @version                1.1.0
        */
        public IEnumerable<Post> PostsView_GetData(int? maximumRows, int? startRowIndex, out int totalRowCount,
            string sortByExpression)
        {
            totalRowCount = this.RowCount;
            return new PostsData().GetPostsFromDB(ThreadId, this.PostsSelected);
        }

        /*
         * The databound event for the posts listview. Here we find the post number
         * and string it before incrementing the counter for next time
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        protected void PostsView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // This control is within the listview and thus we can only find it by searching
            Literal pNumber = (Literal)e.Item.FindControl("PostNumber");
            pNumber.Text = "#" + PostNum.ToString();
            this.PostNum++;
        }

        /*
         * The page change event for a page. First we see if its an interval we need to expand the buffer at
         * then expand it. SetPageProperties is called to ensure page display is correct and data is rebound
         * to update the UI
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       2.0.0
        */
        protected void PostsView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // Intervals of 90 are used (every nine pages) to avoid incremeneting the buffer too often
            if(HuddleCommon.IsDivisible(e.StartRowIndex, (int)(PagingEnum.PagerBufferMultiplier)))
            {
                this.RowCount += (int)PagingEnum.PagerBuffer;
            }

            // Get the current page and set PostsSelected to select the correct data.
            int currentPage = HuddleCommon.CalculateCurrentPage(e.StartRowIndex, e.MaximumRows);
            this.PostsSelected = (currentPage - 1) * 10;

            PostsPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            PostsView.DataBind();
        }

        
    }
}