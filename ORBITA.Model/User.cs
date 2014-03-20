using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORBITA.Model
{
    /// <summary>
    /// User 模型
    /// </summary>
    public class User
    {
        #region Public Properties

        private int uID;
        public int UID
        {
            get { return uID; }
            set { uID = value; }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string pwd;
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public DateTime JoinDate { get; set; }

        public string Login_IP { get; set; }

        public DateTime Login_Date { get; set; }

        #endregion
    }
}
