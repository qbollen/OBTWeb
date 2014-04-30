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
                    this.ObjectDataSourceArticle.SelectParameters["ac_id"].DefaultValue = parentID;
                    AspNetPager1.RecordCount = ArticleManage.GetList(Convert.ToInt32(parentID)).Count;

                }
            }
            else
            {
                acnav = ArticleClassManage.ArticleClassNav(0, acnav);
                AspNetPager1.RecordCount = ArticleManage.GetList(0).Count;
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

        protected void ListViewArticle_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink imagelink = (HyperLink)e.Item.FindControl("HyperLinkImage");
                Image image = (Image)e.Item.FindControl("artimg");
                HyperLink titlelink = (HyperLink)e.Item.FindControl("HyperLinkTitle");
                Literal title = (Literal)e.Item.FindControl("litTitle");
                Label content = (Label)e.Item.FindControl("lbldscription");
                Article article = (Article)((ListViewDataItem)e.Item).DataItem;
                if (!string.IsNullOrEmpty(article.art_title))
                {
                    if (!string.IsNullOrEmpty(article.art_image))
                    {
                        image.ImageUrl = article.art_image;
                        imagelink.NavigateUrl = "ArticleShow.aspx?id=" + article.art_id.ToString();
                    }
                    else
                    {
                        image.Visible = false;
                    }
                                     
                    title.Text = article.art_title;
                    titlelink.NavigateUrl = "ArticleShow.aspx?id=" + article.art_id.ToString();

                    string desc = article.art_description;

                    if (desc.Length > 230)
                    {
                        desc = desc.Substring(0, desc.Substring(0, 230).LastIndexOf(" ")) + " ...";
                    }

                    content.Text = desc;

                }
            }
        }
    }
}