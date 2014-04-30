using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ORBITA.BLL;

namespace ORBITA.UI.Controls
{
    public partial class ProductClassLeft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListViewProductClass_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                 Label lbl = (Label)e.Item.FindControl("lblBlank");


                 HyperLink hlink = (HyperLink)e.Item.FindControl("classitem");
                

                 HtmlGenericControl li = (HtmlGenericControl)e.Item.FindControl("liItem");

                 ListViewDataItem lvDataItem = (ListViewDataItem)e.Item;
                 DataRow row = ((DataRowView)lvDataItem.DataItem).Row;

                 int pc_id = Convert.ToInt32(row["pc_id"]);

                 hlink.Text = row["pc_name"].ToString();

                 if (ProductClassManage.IsParentClass(pc_id)) 
                 {
                     li.Attributes.Add("menu", pc_id.ToString());
                 }
                 else
                 {
                     hlink.NavigateUrl = "~/ProductList.aspx?id=" + pc_id.ToString();
                 }
                 

                 int depth = Convert.ToInt32(row["depth"]);
                 if (depth > 0)
                 {                  
                     string blank = string.Empty;

                     for(int i = 0; i < depth; i++)
                     {
                         blank += "&nbsp;&nbsp;";                     
                     }

                     lbl.Text = blank + "--";
                     //li.Attributes.Add("class", "classnav");
                     li.Attributes.Add("submenu", row["parent_id"].ToString());
                 }

            }
        }
    }
}