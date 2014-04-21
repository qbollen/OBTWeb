using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ORBITA.BLL;
using ORBITA.Model;
using ORBITA.Common;

namespace ORBITA.UI
{
    public partial class ArticleList : System.Web.UI.Page
    {
        public string acnav { get; set; }
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
                acnav = ArticleClassManage.ArticleClassNav(Convert.ToInt32(parentID),acnav);
                if (!IsPostBack)
                {
                    //this.ObjectDataSourceArticleClass.SelectParameters["parent_id"].DefaultValue = parentID;
                    //this.repeaterArticleClass.databind();

                    this.ObjectDataSourceArticle.SelectParameters["ac_id"].DefaultValue = parentID;
                    AspNetPager1.RecordCount = ArticleManage.GetList(Convert.ToInt32(parentID)).Count;

                }
            }
            else
            {
                acnav = ArticleClassManage.ArticleClassNav(2, acnav);
                AspNetPager1.RecordCount = ArticleManage.GetList(2).Count;
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
    }
}