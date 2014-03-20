using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ORBITA.BLL;
using ORBITA.Model;

namespace ORBITA.UI.Admin
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin_user"] != null)
                {
                    Session["admin_user"] = null;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            bool bValiAccount = false;
            bool bValiCode = false;

            //验证账户
            //User tUser = new User();
            //tUser.UserName = txtUserName.Text;
            //tUser.Pwd = txtPwd.Text;
            //try
            //{
            //    if (userManager.ValidateAccount(tUser))
            //    {
            //        //允许登录
            //        bValiAccount = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('" + ex.Message + "'); ", true);
            //    return;
            //}

            User myUser = UserManage.GetItem(this.txtUserName.Text.Trim(), this.txtPwd.Text.Trim());
            if (string.IsNullOrEmpty(myUser.UserName))
            {
                bValiAccount = false;
            }
            else
            {
                bValiAccount = true;
            }

            //验证码判断
            if (txtCode.Text.ToUpper() == HttpContext.Current.Session["CheckCode"].ToString().ToUpper())
            {
                bValiCode = true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Validate code error!'); ", true);
                return;
            }

            if (bValiAccount && bValiCode)
            {
                UserManage.Update(myUser.UID, Request.ServerVariables["REMOTE_ADDR"], DateTime.Now);
                Session["admin_user"] = myUser.UserName;
                Response.Redirect("Default.aspx");
            }
        }
    }
}