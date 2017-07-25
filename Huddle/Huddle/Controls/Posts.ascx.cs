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
            totalRowCount = 10;
            IEnumerable<Post> posts = new PostsData().GetPostsFromDB(ThreadId, this.PostsSelected);

            if(posts.Count() > 9)
            {
                this.PostsSelected += 10;
                return posts;
            }
            return posts;
        }

        protected void PostsView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal pNumber = (Literal)e.Item.FindControl("PostNumber");
            pNumber.Text = "#" + PostNum.ToString();
            this.IncrementPostNum(ref PostNum);
        }

        private void IncrementPostNum(ref int postNumber)
        {
            postNumber++;
        }
    }
}