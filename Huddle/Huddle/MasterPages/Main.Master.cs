using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Huddle.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string themeSelection = Page.Theme;                                    // get the current theme
                HttpCookie prefTheme = Request.Cookies.Get("PrefTheme");               // get the preferred theme

                if(prefTheme != null)
                {
                    themeSelection = prefTheme.Value;                                  // if the cookie was set assign
                }

                if (!string.IsNullOrEmpty(themeSelection))
                {
                    ListItem item = ChooseTheme.Items.FindByValue(themeSelection);     // pre-select that theme if exists
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void ChooseTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpCookie themeSelection = new HttpCookie("PrefTheme");                  // create a new cookie
            themeSelection.Expires = DateTime.Now.AddMonths(2);
            themeSelection.Value = ChooseTheme.SelectedValue;
            Response.Cookies.Add(themeSelection);                                     // add it to the HTTP response
            Response.Redirect(Request.Url.ToString());
        }
    }
}