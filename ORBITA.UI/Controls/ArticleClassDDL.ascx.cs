using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ORBITA.BLL;
using ORBITA.Model;

namespace ORBITA.UI.Controls
{
    public partial class ArticleClassDDL : System.Web.UI.UserControl
    {
        public string CurrentValue { get; set; }
        public DropDownList InnerDropDownListTree
        {
            get
            {
                return this.DropDownListTree;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentValue = this.DropDownListTree.SelectedValue;
        }

        public void LoadTree()
        {
            this.DropDownListTree.Items.Clear();
            DataSet ds = ArticleClassManage.GetTree();
            if(ds.Tables["ArticleClass"].Rows.Count == 0)
            {
                Response.Write("<script type='text/javascript'> alert('请选择文章分类！');document.location.href='ArticleClassAdd.aspx'</script>");
            }

            string strName = null;

            for(int i = 0 ; i < ds.Tables["ArticleClass"].Rows.Count; i++)
            {
                strName = null;
                for (int j = 0; j < Convert.ToInt32(ds.Tables["ArticleClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)(0xa0);
                }
                strName = strName + ">" + ds.Tables["ArticleClass"].Rows[i]["ac_name"].ToString();
                ListItem li = new ListItem(strName, ds.Tables["ArticleClass"].Rows[i]["ac_id"].ToString());
                this.DropDownListTree.Items.Insert(i, li);
            }
        }

        protected void DropDownListTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentValue = this.DropDownListTree.SelectedValue.ToString();
        }
    }
}