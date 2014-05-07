using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data;

using MySql.Data.MySqlClient;

namespace ORBITA.DAL
{
    /// <summary>
    /// 用户管理 Dal
    /// </summary>
    public class UserService
    {
        #region Public Methods

        ///// <summary>
        ///// 查询一条用户记录.
        ///// </summary>
        ///// <param name="userName">用户名</param>
        ///// <returns>User 模型</returns>
        //public User GetSingleUser(string userName)
        //{
        //    string sql = "SELECT * FROM [T_Users] WHERE UserName=@UserName";
        //    OleDbParameter[] parms = {new OleDbParameter("@UserName",OleDbType.VarChar,50)};
        //    parms[0].Value = userName;
        //    DataTable table = DbHelper.ExecuteDataTable(sql, parms);
        //    User tUser = null;
        //    if (table.Rows.Count > 0)
        //    {
        //        tUser = new User();
        //        tUser.UID = Convert.ToInt32(table.Rows[0]["UID"]);
        //        tUser.UserName = table.Rows[0]["UserName"].ToString();
        //        tUser.Pwd = table.Rows[0]["Pwd"].ToString();
        //        tUser.JoinDate = Convert.ToDateTime(table.Rows[0]["JoinDate"]);
        //        tUser.Login_IP = table.Rows[0]["Login_IP"].ToString();
        //        tUser.Login_Date = Convert.ToDateTime(table.Rows[0]["Login_Date"]);
        //    }

        //    return tUser;
        //}

        /// <summary>
        /// 查询用户 所有用户
        /// </summary>
        /// <returns>UserCollection 包含所有记录.</returns>
        public static UserCollection GetList()
        {
            UserCollection list = new UserCollection();
            string sql = "select * from T_Users";
            MySqlDataReader reader = DbHelper.ExecuteDataReader(sql);
            if (reader.HasRows)
            {
                list = new UserCollection();
                while (reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();

            return list;
        }

        /// <summary>
        /// 查询一条用户记录.
        /// </summary>
        /// <param name="myUser">User 模型</param>
        /// <returns>User模型 包含一条用户记录.</returns>
        public static User GetItem(User myUser)
        {
            string sql;

            MySqlParameter[] parms = null;

            if (myUser.UID > 0)
            {
                sql = "select * from T_Users where uid=?uid";
                parms = new MySqlParameter[] { new MySqlParameter("?uid", MySqlDbType.Int32) };
                parms[0].Value = myUser.UID;
            }
            else if(!string.IsNullOrEmpty(myUser.UserName) && !string.IsNullOrEmpty(myUser.Pwd))
            {
                sql = "select * from T_Users where username=?username and password=?pwd";
                parms = new MySqlParameter[] { 
                                                new MySqlParameter("?username",MySqlDbType.VarChar),
                                                new MySqlParameter("?pwd",MySqlDbType.VarChar)
                                             };
                parms[0].Value = myUser.UserName;
                parms[1].Value = myUser.Pwd;
            }
            else
            {
                sql = "select * from T_Users where username=?username";
                parms = new MySqlParameter[] { new MySqlParameter("?username", MySqlDbType.VarChar) };
                parms[0].Value = myUser.UserName;
            }

            User user = new User();

            MySqlDataReader reader = DbHelper.ExecuteDataReader(sql, parms);

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    user = FillDataRecord(reader);
                }
            }
            reader.Close();

            return user;

        }

        /// <summary>
        /// 删除一条用户记录.
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>返回<c>true</c>删除成功,或<c>false</c>删除失败.</returns>
        public static bool Delete(int uid)
        {
            int result = 0;
            string sql = "delete from T_Users where uid=?uid";
            MySqlParameter[] parms = { new MySqlParameter("?uid", MySqlDbType.Int32) };
            parms[0].Value = uid;
            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        /// <summary>
        /// 修改用户记录.
        /// </summary>
        /// <param name="myUser">User 模型</param>
        /// <returns>返回<c>true</c>修改成功,或<c>false</c>修改失败.</returns>
        public static bool Update(User myUser)
        {
            int result = 0;
            string sql;

            MySqlParameter[] parms = null;

            if (!string.IsNullOrEmpty(myUser.Pwd))
            {
                sql = "update T_Users set password=?pwd where uid=?uid";
                parms = new MySqlParameter[]{   
                                                 new MySqlParameter("?pwd",MySqlDbType.VarChar),
                                                 new MySqlParameter("?uid",MySqlDbType.Int32)
                                            };
                parms[0].Value = myUser.Pwd;
                parms[1].Value = myUser.UID;
            }
            else
            {
                sql = "update T_Users set login_ip=?login_ip, login_date=?login_date where uid=?uid";
                parms = new MySqlParameter[] { 
                                                 new MySqlParameter("?login_ip",MySqlDbType.VarChar),
                                                 new MySqlParameter("?login_date",MySqlDbType.Date),
                                                 new MySqlParameter("?uid",MySqlDbType.Int32)
                                              };
                parms[0].Value = myUser.Login_IP;
                parms[1].Value = myUser.Login_Date;
                parms[2].Value = myUser.UID;   
            }
            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        /// <summary>
        /// 插入用户记录.
        /// </summary>
        /// <param name="myUser">User 模型</param>
        /// <returns>返回<c>true</c>插入成功，或<c>false</c>插入失败.</returns>
        public static bool Insert(User myUser)
        {
            int result = 0;
            string sql = @"	INSERT INTO T_Users
		                                (
			                                username, 
			                                password, 
			                                joindate, 
			                                login_ip, 
			                                login_date	
		                                )
	                                VALUES
		                                (
			                                ?username, 
			                                ?pwd, 
			                                ?joindate, 
			                                ?login_ip, 
			                                ?login_date
		                                )";
            MySqlParameter[] parms = { 
                                        new MySqlParameter("?username",MySqlDbType.VarChar),
                                        new MySqlParameter("?pwd",MySqlDbType.VarChar),
                                        new MySqlParameter("?joindate",MySqlDbType.Date),
                                        new MySqlParameter("?login_ip",MySqlDbType.VarChar),
                                        new MySqlParameter("?login_date",MySqlDbType.Date)                                        
                                     };
            parms[0].Value = myUser.UserName;
            parms[1].Value = myUser.Pwd;
            parms[2].Value = myUser.JoinDate;
            parms[3].Value = myUser.Login_IP;
            parms[4].Value = myUser.Login_Date;

            result = DbHelper.ExecuteNonQuery(sql,parms);

            return result > 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 初始化一个user类实例,并填充数据.
        /// </summary>
        /// <param name="myDataRecord"></param>
        /// <returns></returns>
        private static User FillDataRecord(IDataRecord myDataRecord)
        {
            User myUser = new User();

            myUser.UID = myDataRecord.GetInt32(myDataRecord.GetOrdinal("uid"));
            myUser.UserName = myDataRecord.GetString(myDataRecord.GetOrdinal("username"));
            myUser.Pwd = myDataRecord.GetString(myDataRecord.GetOrdinal("password"));
            myUser.JoinDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("joindate"));

            if(!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("login_ip")))
            {
                myUser.Login_IP = myDataRecord.GetString(myDataRecord.GetOrdinal("login_ip"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("login_date")))
            {
                myUser.Login_Date = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("login_date"));
            }

            return myUser;
        }

        #endregion
    }
}
