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
    public partial class ArticleMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadTree();
                if (this.DropDownListTree.SelectedValue != string.Empty)
                {
                    AspNetPager1.RecordCount = ArticleManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
                }
                
            }
        }

        protected void DropDownListTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = ArticleManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
        }

        protected void GridViewArticle_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            AspNetPager1.RecordCount = ArticleManage.GetList(Convert.ToInt32(this.DropDownListTree.SelectedValue)).Count;
        }

        protected void GridViewArticle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgt = (Image)e.Row.FindControl("imgTop");
                Image imgc = (Image)e.Row.FindControl("imgCommend");
                Label lblAcName = (Label)e.Row.FindControl("lblAcName");

                Article myArticle = (Article)e.Row.DataItem;
                if(myArticle.istop)
                {
                    imgt.Visible = true;
                }

                if (myArticle.iscommend)
                {
                    imgc.Visible = true;
                }

                int artID = (Int32)GridViewArticle.DataKeys[e.Row.RowIndex].Value;
                int acID = ArticleManage.GetItem(artID).ac_id;

                lblAcName.Text = ArticleClassManage.GetItem(acID).ac_name;
            }
        }

        protected void ObjectDataSourceArticle_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!e.ExecutingSelectCount)
            {
                e.Arguments.StartRowIndex = this.AspNetPager1.StartRecordIndex;
                e.Arguments.MaximumRows = this.AspNetPager1.PageSize;
            }
        }

        protected void LoadTree()
        {
            this.DropDownListTree.Items.Clear();

            DataSet ds = ArticleClassManage.GetTree();
            string strName = null;

            for(int i = 0; i < ds.Tables["ArticleClass"].Rows.Count; i++)
            {
                strName = null; 
                for (int j = 0; j < Convert.ToInt32(ds.Tables["ArticleClass"].Rows[i]["depth"]); j++)
                {
                    strName = strName + (char)0xa0 + (char)0xa0 + (char)0xa0;
                }

                strName = strName + ">" + ds.Tables["ArticleClass"].Rows[i]["ac_name"].ToString();
                ListItem li = new ListItem(strName, ds.Tables["ArticleClass"].Rows[i]["ac_id"].ToString());

                this.DropDownListTree.Items.Insert(i, li);
            }
        }
    }
}