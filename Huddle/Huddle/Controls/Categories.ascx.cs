﻿using System;
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
    public partial class Categories : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Category> CategoriesListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount,
                                                                string sortByExpression)
        {
            totalRowCount = 10;
            return new CategoriesData().GetCategoriesFromDB();
        }
    }
}