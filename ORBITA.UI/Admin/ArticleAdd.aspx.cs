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
    public partial class ArticleAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticleClassDDL1.LoadTree();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ArticleClassManage.IsLeafNode(Convert.ToInt32(ArticleClassDDL1.CurrentValue)))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),"err", "<script >alert('文章只能添加到子分类，请选择一个正确的分类!');</script>");
            }
            else
            {

                Article myArticle = new Article();

                myArticle.art_title = this.tbxTitle.Text;
                myArticle.art_author = this.tbxAuthor.Text;
                myArticle.art_from = this.tbxFrom.Text;
                myArticle.art_content = CKEditor1.Text;
                myArticle.art_click = 0;
                myArticle.art_date = DateTime.Now;
                myArticle.art_description = this.txtDescription.Value;
                myArticle.istop = this.cbxTop.Checked;
                myArticle.iscommend = this.cbxCommend.Checked;
                myArticle.ac_id = Convert.ToInt32(ArticleClassDDL1.CurrentValue);

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
                        myArticle.art_image = " ";
                    }
                }
                else
                {
                    myArticle.art_image = this.tbxImage.Text.Trim();
                }


                if (ArticleManage.Insert(myArticle))
                {
                    Response.Write("<script>alert('文章添加成功!!!');window.location.href=document.URL;</script>");

                }
                else
                {
                    this.lblError.Visible = true;
                }
            }
        }
    }
}