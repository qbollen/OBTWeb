using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.BLL;
using System.Data;
using ORBITA.Model;

namespace ORBITA.UI.Admin
{
    public partial class ProductMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTree();
                if (this.DropDownListTree.SelectedValue != "")
                {
                    AspNetPager1.RecordCount = ProductManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
                }

            }
        }

        protected void LoadTree()
        {
            this.DropDownListTree.Items.Clear();

            DataSet ds = ProductClassManage.GetTree();
            string strName = null;

            for (int i = 0; i < ds.Tables["T_ProductClass"].Rows.Count; i++)
            {
                strName = null;
                for (int j = 0; j < Convert.ToInt32(ds.Tables["T_ProductClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)0xa0;
                }
                strName = strName + ">" + ds.Tables["T_ProductClass"].Rows[i]["pc_name"].ToString();

                ListItem li = new ListItem(strName, ds.Tables["T_ProductClass"].Rows[i]["pc_id"].ToString());


                this.DropDownListTree.Items.Insert(i, li);
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

        protected void DropDownListTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = ProductManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
        }

        protected void GridViewProduct_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            AspNetPager1.RecordCount = ProductManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
        }

        protected void GridViewProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgt = (Image)e.Row.FindControl("imgTop");
                Image imgc = (Image)e.Row.FindControl("imgCommend");
                Label lblPcName = (Label)e.Row.FindControl("lblPcName");

                Product myProduct = ((Product)e.Row.DataItem);
                if (myProduct.IsTop)
                {
                    imgt.Visible = true;
                }
                if (myProduct.IsCommend)
                {
                    imgc.Visible = true;
                }

                int prodID = (Int32)GridViewProduct.DataKeys[e.Row.RowIndex].Value;
                int pcID = ProductManage.GetItem(prodID).Pc_Id; 

                lblPcName.Text = ProductClassManage.GetItem(pcID).PC_Name;
            }
        }

    }
}