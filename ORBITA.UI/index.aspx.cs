using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Model;

namespace ORBITA.UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void ListViewProductCommend_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink lnk = (HyperLink)e.Item.FindControl("lnkcommend");
                Image img = (Image)e.Item.FindControl("imgcommend");
                Product product = (Product)((ListViewDataItem)e.Item).DataItem;
                if(!string.IsNullOrEmpty(product.Prod_Image))
                {
                    img.ImageUrl = product.Prod_Image;
                    img.AlternateText = product.Prod_Name;
                    lnk.NavigateUrl = "ProductShow.aspx?id=" + product.Prod_Id.ToString();
                }
                else
                {
                    img.ImageUrl = "";
                    img.AlternateText = " ";
                    lnk.NavigateUrl = "#";
                }
            }
        }

        protected void ListViewArticleTop_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.ItemType == ListViewItemType.DataItem)
            {
                Image image = (Image)e.Item.FindControl("image");
                Literal title = (Literal)e.Item.FindControl("litTitle");
                Label desc = (Label)e.Item.FindControl("lblDesc");
                HyperLink more = (HyperLink)e.Item.FindControl("HyperLinkMore");
                Article article = (Article)((ListViewDataItem)e.Item).DataItem;
                if (!string.IsNullOrEmpty(article.art_title))
                {
                    if (!string.IsNullOrEmpty(article.art_image))
                    {
                        image.ImageUrl = article.art_image;
                    }
                    else
                    {
                        image.Visible = false;
                    }
                    title.Text = article.art_title;

                    string description = article.art_description;

                    if (description.Length > 250)
                    {
                        description = description.Substring(0, description.Substring(0, 250).LastIndexOf(" ")) + " ...";
                    }

                    desc.Text = description;

                    more.NavigateUrl = "ArticleShow.aspx?id=" + article.art_id.ToString();
                }
            }
        }
    }
}