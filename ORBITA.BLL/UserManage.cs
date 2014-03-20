using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.DAL;
using ORBITA.Model;
using System.ComponentModel;

namespace ORBITA.BLL
{
    /// <summary>
    /// User Bll.
    /// </summary>
    [DataObjectAttribute()]
    public class UserManage
    {
        //private readonly UserService userService = new UserService();

        #region Public Methods

        //public bool ValidateAccount(User userEntity)
        //{
        //    bool bResult = false;

        //    //验证登录信息是否为空
        //    if ((userEntity.UserName == string.Empty) || (userEntity.Pwd == string.Empty))
        //    {
        //        throw new Exception("UserName and Password can not be empty!");
        //    }

        //    //验证登录信息正确性
        //    User tUser = null;
        //    if ((tUser = userService.GetSingleUser(userEntity.UserName)) != null)
        //    {
        //        if (userEntity.Pwd == tUser.Pwd)
        //        {
        //            bResult = true;
        //        }
        //        else
        //        {
        //            throw new Exception("UserName or Password error!");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("UserName or Password error!");
        //    }

        //    return bResult;
        //}

        /// <summary>
        /// 查询所有用户记录.
        /// </summary>
        /// <returns>用户记录list</returns>
        [DataObjectMethod(DataObjectMethodType.Select,true)]
        public static UserCollection GetList()
        {
            return UserService.GetList();
        }

        /// <summary>
        /// 条件查询一条用户记录.
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>User 模型</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static User GetItem(string username, string password)
        {
            User myUser = new User();
            myUser.UserName = username;
            myUser.Pwd = password;
            return UserService.GetItem(myUser);
        }

        /// <summary>
        /// 条件查询一条用户记录.
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>User模型</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static User GetItem(string username)
        {
            User myUser = new User();
            myUser.UserName = username;
            return UserService.GetItem(myUser);
        }

        /// <summary>
        /// 条件查询一条用户记录.
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns>User模型</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static User GetItem(int uid)
        {
            User myUser = new User();
            myUser.UID = uid;
            return UserService.GetItem(myUser);
        }

        /// <summary>
        /// 删除一条用户记录.
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>返回<c>true</c>删除成功,或<c>false</c>删除失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public static bool Delete(int uid)
        {
            return UserService.Delete(uid);
        }

        /// <summary>
        /// 修改用户密码.
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="password">用户密码</param>
        /// <returns>反回<c>true</c>修改成功,或<c>修改失败.</c></returns>
        [DataObjectMethod(DataObjectMethodType.Update,true)]
        public static bool Update(int uid, string password)
        {
            User myUser = new User();
            myUser.UID = uid;
            myUser.Pwd = password;
            return UserService.Update(myUser);
        }

        /// <summary>
        /// 修改用户登陆IP和时间.
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="loginip">登陆ip</param>
        /// <param name="logindate">登陆时间</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public static bool Update(int uid, string loginip, DateTime logindate)
        {
            User myUser = new User();
            myUser.UID = uid;
            myUser.Login_IP = loginip;
            myUser.Login_Date = logindate;
            return UserService.Update(myUser);
        }

        /// <summary>
        /// 插入一条用户记录.
        /// </summary>
        /// <param name="myUser">User模型</param>
        /// <returns>返回<c>true</c>插入成功,或<c>false</c>插入失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public static bool Insert(User myUser)
        {
            if (string.IsNullOrEmpty(myUser.UserName) || string.IsNullOrEmpty(myUser.Pwd) || string.IsNullOrEmpty(myUser.Login_IP))
            {
                return false;
            }
            else
            {
                myUser.JoinDate = DateTime.Now;
                myUser.Login_Date = DateTime.Now;
                return UserService.Insert(myUser);
            }
        }

        #endregion
    }
}
