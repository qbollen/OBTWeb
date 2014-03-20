using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ORBITA.Common;
using ORBITA.BLL;

namespace ORBITA.UI.MasterPage
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string pcnav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string parentID = null;
            try
            {
                parentID = Request.QueryString["id"].ToString();
            }
            catch (Exception ex)
            {
            }

            if (BaseCommon.ValidQueryString(parentID))
            {
                pcnav = ProductClassManage.ProductClassNav(Convert.ToInt32(parentID), pcnav);

            }
        }

        protected void RepeaterProductClass_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (RepeaterProductClass.Items.Count == 0)
            {
                this.RepeaterProductClass.Visible = false;
            }
            else
            {
                this.RepeaterProductClass.Visible = true;
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl = (Label)e.Item.FindControl("lblBlank");
                Image img = (Image)e.Item.FindControl("imgBar");

                DataRow row = (DataRow)((DataRowView)e.Item.DataItem).Row;

                if (Convert.ToInt32(row["depth"]) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(row["depth"]); i++)
                    {
                        lbl.Text = lbl.Text + "&nbsp;";
                        img.ImageUrl = "~/Images/bot2.gif";
                    }
                }

            }
        }
    }
}