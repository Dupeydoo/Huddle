using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Huddle.Data.ModelBinding;
using Huddle.Objects;

namespace Huddle.Controls
{
    /*
     * The User control providing the category table to the interface.
     * 
     * @author  James
     * @version 1.0.0
    */
    public partial class Categories : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e) { }

        /*
         * The method which calls the data layer to select category data.
         * 
         * @param maximumRows      The maximum rows displayed at one time
         * @param starRowIndex     A counter which keeps track of the current data pages start
         * @param totalRowCount    The total amount of rows selected
         * @param sortByExpression An expression to sort data by
         * @see                    Huddle.Data.ModelBinding.CategoriesData
         * @returns                An IEnumerable of non ef wrapped category objects
         * @author                 James
         * @version                1.0.0
        */
        public IEnumerable<Category> CategoriesListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount,
                                                                string sortByExpression)
        {
            totalRowCount = 10;
            return new CategoriesData().GetCategoriesFromDB();
        }
    }
}