using System;
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
        public int ThreadId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Post> PostsView_GetData(int? maximumRows, int? startRowIndex, out int totalRowCount, 
            string sortByExpression)
        {
            totalRowCount = 5;
            return new PostsData().GetPostsFromDB(ThreadId);
        }
    }
}