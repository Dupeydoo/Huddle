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
    public partial class Threads : System.Web.UI.UserControl
    {
        public int CategoryId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SectionHeading.Text = Page.Title;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Thread> StickyListView_GetData(int maximumRows, int startRowIndex, 
            out int totalRowCount, string sortByExpression)
        {
            totalRowCount = 10;
            return new ThreadsData().GetCategoryThreadsFromDB(CategoryId, true);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Thread> ThreadListView_GetData(int maximumRows, int startRowIndex,
            out int totalRowCount, string sortByExpression)
        {
            totalRowCount = 10;
            return new ThreadsData().GetCategoryThreadsFromDB(CategoryId, false);
        }
    }
}