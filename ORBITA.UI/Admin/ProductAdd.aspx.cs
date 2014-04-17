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
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductClassDDL1.LoadTree();
            }

            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "";
            _FileBrowser.SetupCKEditor(CKEditor1);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ProductClassManage.IsLeafNode(Convert.ToInt32(ProductClassDDL1.currentValue)))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"err", "<script>alert('产品只能添加到子分类',请选择一个正确的分类!);</script>");
            }
            else
            {
                Product myProduct = new Product();

                myProduct.Prod_Name = this.txtName.Text;
                myProduct.Prod_Number = this.txtNumber.Text;

                if (!string.IsNullOrEmpty(this.txtPrice.Text))
                {
                    myProduct.Prod_Price = Convert.ToDecimal(this.txtPrice.Text);
                }

                myProduct.Prod_Content = CKEditor1.Text;
                myProduct.Prod_Click = 0;
                myProduct.Prod_Date = DateTime.Now;
                myProduct.IsTop = this.cbxTop.Checked;
                myProduct.IsCommend = this.cbxCommand.Checked;

                myProduct.Pc_Id = Convert.ToInt32(ProductClassDDL1.currentValue);

                if (string.IsNullOrEmpty(this.txtImage.Text) || this.txtImage.Text == "")
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
                    myProduct.Prod_Image = this.txtImage.Text.Trim();
                }

                if (ProductManage.Insert(myProduct))
                {
                    Response.Write("<script>alert('产品添加成功!!!');window.location.href=document.URL;</script>");
                }
                else
                {
                    this.lblError.Visible = true;
                }
            }
        }
    }
}