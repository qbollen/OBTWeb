using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ORBITA.BLL;
using ORBITA.Model;

namespace ORBITA.UI.Admin
{
    public partial class ProductClassMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxacname.Text.Trim()))
            {
                this.lblError.Visible = true;
            }
            else
            {
                if (ProductClassManage.Update(Convert.ToInt32(ViewState["pc_id"]), this.tbxacname.Text.Trim()))
                {
                    this.Panel1.Visible = false;
                    this.RepeaterTree.DataBind();
                }
                else
                {
                    this.lblError.Text = "数据更新失败，请重试！！！" + ViewState["pc_id"].ToString() + this.tbxacname.Text.Trim();
                    this.lblError.Visible = true;
                }
            }
        }

        protected void RepeaterTree_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lb = (LinkButton)e.Item.FindControl("lbtDelete");
                Label lbl = (Label)e.Item.FindControl("lblBlank");

                DataRow row = (DataRow)((DataRowView)e.Item.DataItem).Row;

                if (Convert.ToInt32(row["depth"]) > 0)
                {
                    for (int i = 0; i < Convert.ToInt32(row["depth"]); i++)
                    {
                        lbl.Text = lbl.Text + "&nbsp;&nbsp;&nbsp;&nbsp;";
                    }
                }

                lb.OnClientClick =
                    string.Format("return confirm('你确认要删除 \"{0}\" 这个分类吗？');", row["pc_name"].ToString().Replace("'", @"\'"));
             
            }
        }

        protected void RepeaterTree_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(string.Compare(e.CommandName, "Delete", true) == 0)
            {
                if (ProductClassManage.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    this.lblErrDelete.Visible = false;
                }
                else
                {
                    this.lblErrDelete.Visible = true;
                }
                this.RepeaterTree.DataBind();
            }

            if (string.Compare(e.CommandName, "Edit", true) == 0)
            {
                ViewState["pc_id"] = Convert.ToInt32(e.CommandArgument);
                ProductClass myProductClass = ProductClassManage.GetItem(Convert.ToInt32(ViewState["pc_id"]));
                ViewState["pc_name"] = myProductClass.PC_Name;

                this.Panel1.Visible = true;

                this.tbxacname.Text = ViewState["pc_name"].ToString();
            }
            this.lblError.Visible = false;
        }
    }
}