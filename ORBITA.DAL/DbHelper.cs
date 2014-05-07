﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

using MySql.Data.MySqlClient;

namespace ORBITA.DAL
{
    public sealed class DbHelper
    {       

        public static string Connection
        {
            get
            {
                return PubConstant.GetConnection();
            }
        }

        private DbHelper()
        {

        }

        /// <summary>
        /// 执行非查询
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>受影响的行数.</returns>
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                if ((parameters != null) && (parameters.Length > 0))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql">sql 语句</param>
        /// <param name="tablename">指定DataSet中的表，不指定传null</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteDataSet(string sql, string tablename, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                if ((parameters != null) && (parameters.Length > 0))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }

                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                if (tablename != null)
                {
                    adapter.Fill(ds, tablename);
                }
                else
                {
                    adapter.Fill(ds);
                }

                return ds;
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回OleDbDataReader</returns>
        public static MySqlDataReader ExecuteDataReader(string sql, params MySqlParameter[] parameters)
        {
            MySqlConnection conn = new MySqlConnection(Connection);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            if ((parameters != null) && (parameters.Length > 0))
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parameters);
            }
            
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);  
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回object类型单值</returns>
        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                if ((parameters != null) && (parameters.Length > 0))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteScalar();
            }
        }
    }
}
