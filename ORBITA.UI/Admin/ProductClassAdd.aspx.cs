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
    public partial class ProductClassAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTree();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ProductClass myProductClass = new ProductClass();

            myProductClass.PC_Name = this.txtAcname.Text.Trim();
            myProductClass.Parent_Id = Convert.ToInt32(this.DropDownListTree.SelectedValue);

            if (ProductClassManage.Insert(myProductClass))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加产品分类成功!!!')", true);
                LoadTree();
            }
            else
            {
                this.lblError.Visible = true;
            }
        }

        protected void LoadTree()
        {
            this.DropDownListTree.Items.Clear();

            DataSet ds = ProductClassManage.GetTree();
            string strName = null;
            this.DropDownListTree.Items.Insert(0, new ListItem("无 (做为一级分类)", "0"));

            for (int i = 0; i < ds.Tables["ProductClass"].Rows.Count; i++)
            {
                strName = null;
                for (int j = 0; j < Convert.ToInt32(ds.Tables["ProductClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)0xa0;
                }
                strName = strName + ">" + ds.Tables["ProductClass"].Rows[i]["pc_name"].ToString();

                ListItem li = new ListItem(strName, ds.Tables["ProductClass"].Rows[i]["pc_id"].ToString());

                this.DropDownListTree.Items.Insert(i + 1, li);
            }
            
        }
    }
}