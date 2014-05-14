using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.BLL;
using ORBITA.Model;
using System.Text.RegularExpressions;

namespace ORBITA.UI.Admin
{
    public partial class ArticleEdit : System.Web.UI.Page
    {
        static Article myArticle = new Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    myArticle = ArticleManage.GetItem(Convert.ToInt32(Request.QueryString["id"]));

                    if (string.IsNullOrEmpty(myArticle.art_title))
                    {
                        Response.Write("<script type='text/javascript'>alert('错误的链接!');document.location.href='ArticleMgmt.aspx'</script>");
                    }
                    else
                    {
                        this.ArticleClassDDL1.LoadTree();
                        this.ArticleClassDDL1.InnerDropDownListTree.Items.FindByValue(myArticle.ac_id.ToString()).Selected = true;

                        this.tbxTitle.Text = myArticle.art_title;
                        this.tbxAuthor.Text = myArticle.art_author;
                        this.tbxFrom.Text = myArticle.art_from;
                        this.tbxImage.Text = myArticle.art_image;
                        CKEditor1.Text = myArticle.art_content;
                        this.txtDescription.Value = myArticle.art_description;
                        this.cbxTop.Checked = myArticle.istop;
                        this.cbxCommend.Checked = myArticle.iscommend;
                        Page.Title = myArticle.art_title;
                    }
                }
                else
                {
                    Response.Write("<script language=JavaScript>alert('错误的链接!');document.location.href='ArticleMgmt.aspx'</script>");
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ArticleClassManage.IsLeafNode(Convert.ToInt32(ArticleClassDDL1.CurrentValue)))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),"err", "<script >alert('文章只能添加到子分类，请选择一个正确的分类!');</script>");
            }
            else
            {
                string SelectedValue = ArticleClassDDL1.CurrentValue;
                myArticle.art_title = this.tbxTitle.Text;
                myArticle.art_author = this.tbxAuthor.Text;
                myArticle.art_from = this.tbxFrom.Text;
                myArticle.art_content = CKEditor1.Text;
                myArticle.art_date = DateTime.Now;
                myArticle.art_description = this.txtDescription.Value;
                myArticle.istop = this.cbxTop.Checked;
                myArticle.iscommend = this.cbxCommend.Checked;
                myArticle.ac_id = Convert.ToInt32(SelectedValue);
                myArticle.art_image = this.tbxImage.Text;
                if (string.IsNullOrEmpty(this.tbxImage.Text) || this.tbxImage.Text == " ")
                {
                    string fckStr = CKEditor1.Text;
                    MatchCollection matchs = Regex.Matches(fckStr, @"<img[^src]*src=""[^http\://]*(?<src>[^""]*?)""", RegexOptions.IgnoreCase);
                    foreach (Match m in matchs)
                    {
                        myArticle.art_image = m.Groups["src"].Value.ToString();
                        break;
                    }
                    if (string.IsNullOrEmpty(myArticle.art_image))
                    {
                        myArticle.art_image = "";
                    }
                }
                else
                {
                    myArticle.art_image = this.tbxImage.Text.Trim();
                }

                if (ArticleManage.Update(myArticle))
                {
                    Response.Write("<script language=JavaScript>alert('文章修改成功!!!');window.location.href='ArticleMgmt.aspx';</script>");

                }
                else
                {
                    this.lblError.Text = myArticle.art_id.ToString();
                    this.lblError.Visible = true;
                }
            }
        }
    }
}