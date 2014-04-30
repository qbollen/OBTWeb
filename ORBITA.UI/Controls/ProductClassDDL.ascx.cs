using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.BLL;
using System.Data;

namespace ORBITA.UI.Controls
{
    public partial class ProductClassDDL : System.Web.UI.UserControl
    {
        public string currentValue { get; set; }

        public DropDownList InnerDropDownListTree
        {
            get
            {
                return this.DropDownListTree;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            currentValue = this.DropDownListTree.SelectedValue;
        }

        public void LoadTree()
        {
            this.DropDownListTree.Items.Clear();

            DataSet ds = ProductClassManage.GetTree();

            if (ds.Tables["ProductClass"].Rows.Count == 0)
            {
                Response.Write("<script type='text/javascript'>alert('请先填加产品分类!');document.location.href='ProductClassAdd.aspx'</script>");
            }

            string strName = null;

            for (int i = 0; i < ds.Tables["ProductClass"].Rows.Count; i++)
            {
                strName = null;
                for (int j = 0; j < Convert.ToInt32(ds.Tables["ProductClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)0xa0;
                }
                strName = strName + ">" + ds.Tables["ProductClass"].Rows[i]["pc_name"].ToString();

                ListItem li = new ListItem(strName, ds.Tables["ProductClass"].Rows[i]["pc_id"].ToString());

                this.DropDownListTree.Items.Insert(i, li);
            }
        }

        protected void DropDownListTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentValue = this.DropDownListTree.SelectedValue.ToString();
        }
    }
}