using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Common;
using ORBITA.BLL;
using ORBITA.Model;
using System.Web.UI.HtmlControls;

namespace ORBITA.UI
{
    public partial class ProductShow : System.Web.UI.Page
    {
        public string pcnav { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string prodId = null;
                try
                {
                    prodId = Request.QueryString["id"].ToString();
                }
                catch (Exception ex)
                {
                }

                Product myProduct = new Product();
                if (BaseCommon.ValidQueryString(prodId))
                {
                    ProductManage.Update(Convert.ToInt32(prodId));
                    myProduct = ProductManage.GetItem(Convert.ToInt32(prodId));

                    pcnav = ProductClassManage.ProductClassNav(Convert.ToInt32(myProduct.Pc_Id), pcnav);

                    Page.Title = myProduct.Prod_Name;
                    //HtmlMeta keywords = (HtmlMeta)Master.FindControl("keywords");
                    //HtmlMeta Description = (HtmlMeta)Master.FindControl("Description");

                    //keywords.Attributes["content"] = keywords.Attributes["content"] + "," + myProduct.Prod_Name;
                   // Description.Attributes["content"] = Description.Attributes["content"] + "," + myProduct.Prod_Name;

                    this.lblTitle.Text = myProduct.Prod_Name;
                    this.lblDate.Text = myProduct.Prod_Date.ToString();
                    this.lblPrice.Text = myProduct.Prod_Price.ToString("C");
                    this.lblNumber.Text = myProduct.Prod_Number;
                    this.lblClick.Text = myProduct.Prod_Click.ToString();
                    this.lblContent.Text = myProduct.Prod_Content;
                }
                else
                {
                    Response.Write("错误的链接!");
                }
            }
        }
    }
}