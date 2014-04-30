using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ORBITA.BLL;
using ORBITA.Model;
using System.Web.UI.HtmlControls;
using ORBITA.Common;

namespace ORBITA.UI
{
    public partial class ArticleShow : System.Web.UI.Page
    {
        public string acnav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Master.SetSiteProperty();
                string artID = null;
                try
                {
                    artID = Request.QueryString["id"].ToString();
                }
                catch (Exception ex)
                { }

                Article myArticle = new Article();
                if(BaseCommon.ValidQueryString(artID))
                {
                    ArticleManage.Update(Convert.ToInt32(artID));
                    myArticle = ArticleManage.GetItem(Convert.ToInt32(artID));

                    acnav = ArticleClassManage.ArticleClassNav(myArticle.ac_id, acnav);
                    Page.Title = myArticle.art_title;
                    
                    HtmlMeta keywords = (HtmlMeta)Master.FindControl("keywords");
                    HtmlMeta Description = (HtmlMeta)Master.FindControl("Description");
                  
                    keywords.Attributes["content"] = keywords.Attributes["content"] + "," + myArticle.art_title;
                    Description.Attributes["content"] = Description.Attributes["content"] + "," + myArticle.art_description;

                    this.litTitle.Text = myArticle.art_title;
                    this.lblDate.Text = myArticle.art_date.ToString();
                    this.lblAuthor.Text = myArticle.art_author;
                    this.lblSource.Text = myArticle.art_from;
                    this.lblBrowse.Text = myArticle.art_click.ToString();
                    this.lblContent.Text = myArticle.art_content;

                }
                else
                {
                    Response.Write("错误的连接！");
                }
            }
        }
    }
}