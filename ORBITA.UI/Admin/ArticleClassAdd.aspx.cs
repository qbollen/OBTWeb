using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.BLL;
using ORBITA.Model;

namespace ORBITA.UI.Admin
{
    public partial class ArticleClassAdd : System.Web.UI.Page
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
            ArticleClass myArticleClass = new ArticleClass();
            myArticleClass.ac_name = this.tbxAcname.Text.Trim();
            myArticleClass.parent_id = Convert.ToInt32(this.DropDownListTree.SelectedValue);

            if(ArticleClassManage.Insert(myArticleClass))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click",
                    "alert('添加文章分类成功!!!')", true);
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
            DataSet ds = ArticleClassManage.GetTree();
            string strName = null;
            this.DropDownListTree.Items.Insert(0, new ListItem("无(做为一级分类)", "0"));

            for(int i = 0 ; i < ds.Tables["ArticleClass"].Rows.Count; i++)
            {
                strName = null;
                for(int j = 0; j < Convert.ToInt32(ds.Tables["ArticleClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)0xa0;
                }

                strName = strName + ">" + ds.Tables["ArticleClass"].Rows[i]["ac_name"].ToString();
                ListItem li = new ListItem(strName, ds.Tables["ArticleClass"].Rows[i]["ac_id"].ToString());

                this.DropDownListTree.Items.Insert(i + 1, li);
            }
        }
    }
}