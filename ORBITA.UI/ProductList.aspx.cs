using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Common;
using ORBITA.BLL;
using System.Data;

namespace ORBITA.UI
{
    public partial class ProductList : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                   this.ObjectDataSourceProductClass.SelectParameters["parent_id"].DefaultValue = parentID;
                   // this.RepeaterProductClass.DataBind();

                    this.ObjectDataSourceProduct.SelectParameters["pc_id"].DefaultValue = parentID;
                    AspNetPager1.RecordCount = ProductManage.GetList(Convert.ToInt32(parentID)).Count;
                }
            }
            else
            {
                AspNetPager1.RecordCount = ProductManage.GetList(0).Count;
            }
        }

        protected void RepeaterProductClass_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (ListViewProductClass.Items.Count == 0)
            {
                this.ListViewProductClass.Visible = false;
            }
            else
            {
                this.ListViewProductClass.Visible = true;
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label lbl = (Label)e.Item.FindControl("lblBlank");
                //Image img = (Image)e.Item.FindControl("imgBar");

                DataRow row = (DataRow)((DataRowView)e.Item.DataItem).Row;

                if (Convert.ToInt32(row["depth"]) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(row["depth"]); i++)
                    {
                        //lbl.Text = lbl.Text + "&nbsp;";
                        //img.ImageUrl = "~/Images/bot2.gif";
                    }
                }

            }
        }

        protected void ObjectDataSourceProduct_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!e.ExecutingSelectCount)
            {
                e.Arguments.StartRowIndex = this.AspNetPager1.StartRecordIndex;
                e.Arguments.MaximumRows = this.AspNetPager1.PageSize;
            }
        }
    }
}