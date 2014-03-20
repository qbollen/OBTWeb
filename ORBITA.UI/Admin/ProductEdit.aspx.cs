using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Model;
using ORBITA.BLL;
using System.Text.RegularExpressions;

namespace ORBITA.UI.Admin
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        static Product myProduct = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    myProduct = ProductManage.GetItem(Convert.ToInt32(Request.QueryString["id"]));

                    if (string.IsNullOrEmpty(myProduct.Prod_Name))
                    {
                        Response.Write("<script language=JavaScript>alert('错误的链接!');document.location.href='ProductMgmt.aspx'</script>");
                    }
                    else
                    {
                        this.ProductClassDDL1.LoadTree();
                        this.ProductClassDDL1.InnerDropDownListTree.Items.FindByValue(myProduct.Pc_Id.ToString()).Selected = true;

                        this.tbxName.Text = myProduct.Prod_Name;
                        this.tbxNumber.Text = myProduct.Prod_Number;
                        this.tbxPrice.Text = string.Format("{0:N2}", myProduct.Prod_Price);
                        this.tbxImage.Text = myProduct.Prod_Image;
                        CKEditor1.Text = myProduct.Prod_Content;
                        this.cbxTop.Checked = myProduct.IsTop;
                        this.cbxCommend.Checked = myProduct.IsCommend;
                        Page.Title = myProduct.Prod_Name;
                    }

                }
                else
                {
                    Response.Write("<script language=JavaScript>alert('错误的链接!');document.location.href='ProductMgmt.aspx'</script>");
                }

            }

            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "";
            _FileBrowser.SetupCKEditor(CKEditor1);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ProductClassManage.IsLeafNode(Convert.ToInt32(ProductClassDDL1.currentValue)))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"err", "<script >alert('产品只能添加到子分类，请选择一个正确的分类!');</script>");
            }
            else
            {
                string SelectedValue = ProductClassDDL1.currentValue;
                myProduct.Prod_Name = this.tbxName.Text;
                myProduct.Prod_Number = this.tbxNumber.Text;
                if (!string.IsNullOrEmpty(this.tbxPrice.Text))
                {
                    myProduct.Prod_Price = Convert.ToDecimal(this.tbxPrice.Text);
                }
                myProduct.Prod_Content = CKEditor1.Text;
                myProduct.Prod_Click = 0;
                myProduct.Prod_Date = DateTime.Now;
                myProduct.IsTop = this.cbxTop.Checked;
                myProduct.IsCommend = this.cbxCommend.Checked;
                myProduct.Pc_Id = Convert.ToInt32(ProductClassDDL1.currentValue);

                if (string.IsNullOrEmpty(this.tbxImage.Text) || this.tbxImage.Text == " ")
                {
                    string fckStr = CKEditor1.Text;
                    MatchCollection matchs = Regex.Matches(fckStr, @"<img[^src]*src=""[^http\://]*(?<src>[^""]*?)""", RegexOptions.IgnoreCase);
                    foreach (Match m in matchs)
                    {
                        myProduct.Prod_Image = m.Groups["src"].Value.ToString();
                        break;
                    }
                    if (string.IsNullOrEmpty(myProduct.Prod_Image))
                    {
                        myProduct.Prod_Image = " ";
                    }
                }
                else
                {
                    myProduct.Prod_Image = this.tbxImage.Text.Trim();
                }

                if (ProductManage.Update(myProduct))
                {
                    Response.Write("<script language=JavaScript>alert('产品修改成功!!!');window.location.href='ProductMgmt.aspx';</script>");

                }
                else
                {
                    this.lblError.Text = myProduct.Prod_Id.ToString();
                    this.lblError.Visible = true;
                }
            }
        }
    }
}