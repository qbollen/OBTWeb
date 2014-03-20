using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ORBITA.Model;
using System.Configuration;
using ORBITA.BLL;
using System.Web.Security;

namespace ORBITA.UI.Admin
{
    public partial class UserChng : System.Web.UI.Page
    {
        private static User myUser = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            RegexStringValidator rsv = new RegexStringValidator(@"^[1-9]\d*$");

            try
            {
                rsv.Validate(Request.QueryString["id"].Trim());
                myUser = UserManage.GetItem(Convert.ToInt32(Request.QueryString["id"]));

                this.tbxNewPass.Enabled = true;
                this.tbxOldPass.Enabled = true;
                this.tbxCfmPass.Enabled = true;
                this.btnConfirm.Enabled = true;

                this.lblUser.Text = myUser.UserName;
            }
            catch (ArgumentException ex)
            {
                this.lblError.Visible = true;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (myUser.Pwd == this.tbxOldPass.Text)
            {
                myUser.Pwd = this.tbxNewPass.Text;
                UserManage.Update(myUser.UID, myUser.Pwd);

                Response.Redirect("UserMgmt.aspx");
            }
            else
            {
                this.lblError.Visible = true;
            }
        }
    }
}