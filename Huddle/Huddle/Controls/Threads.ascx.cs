using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Huddle.Data.ModelBinding;
using Huddle.Objects;

namespace Huddle.Controls
{
    /*
     * The threads control providing the repeated format of threads
     * when viewing a category.
     * 
     * @author  James
     * @version 1.2.0
    */
    public partial class Threads : System.Web.UI.UserControl
    {
        public int CategoryId { get; set; }      // The category id of a thread passed via the controls attributes to save extra data selection

        /*
         * The pageload event for a page. The section heading is retrieved from the page title to save
         * any connection to the database.
         * 
         * @param sender  Control who is actioned upon
         * @param e       Arguments to the event
         * @author        James
         * @version       1.0.0
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            SectionHeading.Text = Page.Title;
        }

        /*
         * A method which solely returns sticky threads to the sticky listview.
         * 
         * @see      Huddle.Data.ModelBinding.ThreadsData
         * @returns  An IEnumerable of non ef wrapped sticky threads
         * @author   James
         * @version  1.0.0
        */
        public IEnumerable<Thread> StickyListView_GetData()
        {
            return new ThreadsData().GetCategoryThreadsFromDB(CategoryId, true);
        }

        /*
         * A method which selects the ordinary threads and displays them.
         * 
         * @param maximumRows      The maximum rows displayed at one time
         * @param starRowIndex     A counter which keeps track of the current data pages start
         * @param totalRowCount    The total amount of rows selected
         * @param sortByExpression An expression to sort data by
         * @see                    Huddle.Data.ModelBinding.Thread
         * @returns                An IEnumerable of none ef wrapped thread objects
         * @author                 James
         * @version                1.0.0
        */
        public IEnumerable<Thread> ThreadListView_GetData(int? maximumRows, int? startRowIndex, out int totalRowCount, 
            string sortByExpression)
        {
            totalRowCount = 10;
            return new ThreadsData().GetCategoryThreadsFromDB(CategoryId, false);
        }
    }
}