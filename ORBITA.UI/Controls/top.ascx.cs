using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORBITA.UI.Controls
{
    public partial class top : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListViewProductClass_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //if (ListViewProductClass.Items.Count == 0)
            //{
            //    this.ListViewProductClass.Visible = false;
            //}
            //else
            //{
            //    this.ListViewProductClass.Visible = true;
            //}
        }
    }
}