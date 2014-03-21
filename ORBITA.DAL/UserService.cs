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
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_user_select_list",myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            list = new UserCollection();
                            while(myReader.Read())
                            {
                                list.Add(FillDataRecord(myReader));
                            }
                        }

                        myReader.Close();
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 查询一条用户记录.
        /// </summary>
        /// <param name="myUser">User 模型</param>
        /// <returns>User模型 包含一条用户记录.</returns>
        public static User GetItem(User myUser)
        {
            User tempUser = new User();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_user_select_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    if (myUser.UID > 0)
                    {
                        myCommand.Parameters.AddWithValue("_uid", myUser.UID);
                        myCommand.Parameters.AddWithValue("_username", DBNull.Value);
                        myCommand.Parameters.AddWithValue("_password", DBNull.Value);
                    }
                    else if(!string.IsNullOrEmpty(myUser.UserName) && !string.IsNullOrEmpty(myUser.Pwd))
                    {
                        myCommand.Parameters.AddWithValue("_uid", 0);
                        myCommand.Parameters.AddWithValue("_username", myUser.UserName);
                        myCommand.Parameters.AddWithValue("_password", myUser.Pwd);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_uid", 0);
                        myCommand.Parameters.AddWithValue("_username", myUser.UserName);
                        myCommand.Parameters.AddWithValue("_password", DBNull.Value);
                    }
                    myConnection.Open();
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                tempUser = FillDataRecord(myReader);
                            }
                        }
                        myReader.Close();
                    }
                }
            }

            return tempUser;
        }

        /// <summary>
        /// 删除一条用户记录.
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns>返回<c>true</c>删除成功,或<c>false</c>删除失败.</returns>
        public static bool Delete(int uid)
        {
            int result = 0;
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_user_delete_single_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_uid", uid);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
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
            
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_user_update_single_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_uid", myUser.UID);
                    if (!string.IsNullOrEmpty(myUser.Pwd))
                    {
                        myCommand.Parameters.AddWithValue("_password", myUser.Pwd);
                        myCommand.Parameters.AddWithValue("_login_ip", DBNull.Value);
                        myCommand.Parameters.AddWithValue("_login_date", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_password", DBNull.Value);
                        myCommand.Parameters.AddWithValue("_login_ip", myUser.Login_IP);
                        myCommand.Parameters.AddWithValue("_login_date", myUser.Login_Date);
                    }

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }

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
            
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_user_insert", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_username", myUser.UserName);
                    myCommand.Parameters.AddWithValue("_password", myUser.Pwd);
                    myCommand.Parameters.AddWithValue("_joindate", myUser.JoinDate);
                    myCommand.Parameters.AddWithValue("_login_ip", myUser.Login_IP);
                    myCommand.Parameters.AddWithValue("_login_date", myUser.Login_Date);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();

                }
            }

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

            myUser.UID = myDataRecord.GetInt32(myDataRecord.GetOrdinal("UID"));
            myUser.UserName = myDataRecord.GetString(myDataRecord.GetOrdinal("UserName"));
            myUser.Pwd = myDataRecord.GetString(myDataRecord.GetOrdinal("Pwd"));
            myUser.JoinDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("JoinDate"));

            if(!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Login_IP")))
            {
                myUser.Login_IP = myDataRecord.GetString(myDataRecord.GetOrdinal("Login_IP"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Login_Date")))
            {
                myUser.Login_Date = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Login_Date"));
            }

            return myUser;
        }

        #endregion
    }
}
