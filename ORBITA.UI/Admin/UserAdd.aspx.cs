using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ORBITA.Model;
using ORBITA.BLL;
using System.Web.Security;

namespace ORBITA.UI.Admin
{
    public partial class UserAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            User myUser = new User();

            myUser.UserName = this.tbxUsername.Text.Trim();
            myUser.Pwd = this.tbxPassword.Text;
            myUser.JoinDate = DateTime.Now;
            myUser.Login_IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            myUser.Login_Date = DateTime.Now;

            if (UserManage.Insert(myUser))
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加用户成功!!!')", true);
            }
            else
            {
                this.lblError.Visible = true;
            }
        }
    }
}