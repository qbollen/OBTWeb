using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.BLL;

using System.Web.UI.HtmlControls;

namespace ORBITA.UI.Controls
{
    public partial class ArticleClassLeft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListViewArticleClass_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HtmlGenericControl li = (HtmlGenericControl)e.Item.FindControl("liItem");

                Label lblBlank = (Label)e.Item.FindControl("lblBlank");

                HyperLink hlink = (HyperLink)e.Item.FindControl("classitem");

                DataRowView rowView = (DataRowView)((ListViewDataItem)e.Item).DataItem;

                int ac_id = Convert.ToInt32(rowView["ac_id"]);
                int depth = Convert.ToInt32(rowView["depth"]);

                hlink.Text = rowView["ac_name"].ToString();

                if (ArticleClassManage.IsParentClass(ac_id))
                {
                    li.Attributes.Add("menu", ac_id.ToString());
                }
                else
                {
                    hlink.NavigateUrl = "~/ArticleList.aspx?id=" + ac_id.ToString();
                }

                string blank = string.Empty;
                if (depth > 0)
                {
                    for (int i = 0; i < depth; i++)
                    {
                        blank += "&nbsp;&nbsp";
                    }
                    lblBlank.Text = blank + "--";

                    li.Attributes.Add("submenu", rowView["parent_id"].ToString());
                }
            }
        }
    }
}