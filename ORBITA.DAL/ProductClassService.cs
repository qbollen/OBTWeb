using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ORBITA.DAL
{
    /// <summary>
    /// 产品分类管理 Dal
    /// </summary>
    public class ProductClassService
    {
        #region Public Methods

        ///<summary>查询产品分类 所有数据</summary>
        ///<returns>ProductClassCollection 包含所有记录.</returns>
        public static ProductClassCollection GetList()
        {
            ProductClassCollection list = new ProductClassCollection();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_select_list", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            list = new ProductClassCollection();
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

        ///<summary>条件查询产品分类</summary>
        ///<param name="parent_id">父亲ID 没有传 null</param>
        ///<returns>ProductClassCollection包含条件查询的记录</returns>
        public static ProductClassCollection GetListByParentId(int parent_id)
        {
            ProductClassCollection list = new ProductClassCollection();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_select_list_by_parentid", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (parent_id > 0)
                    {
                        myCommand.Parameters.AddWithValue("_parent_id", parent_id);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_parent_id", DBNull.Value);
                    }

                    myConnection.Open();
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            list = new ProductClassCollection();
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

        ///<summary>条件查询产品分类</summary>
        ///<param name="pc_id">产品分类Id</param>
        ///<returns>ProductClass模型 包含一条产品分类记录.</returns>
        public static ProductClass GetItem(int pc_id)
        {
            ProductClass myProductClass = new ProductClass();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_select_item",myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_pc_id", pc_id);
                    myConnection.Open();
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                myProductClass = FillDataRecord(myReader);
                            }
                        }

                        myReader.Close();
                    }
                }
            }
            return myProductClass;

        }

        ///<summary>查询产品分类树</summary>
        ///<returns>DataSet 包含产品分类树记录.</returns>
        public static DataSet GetTree()
        {
            DataSet ds = new DataSet();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlDataAdapter myAdapter = new MySqlDataAdapter())
                {
                    MySqlCommand myCommand = new MySqlCommand("sproc_product_class_get_tree", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myAdapter.SelectCommand = myCommand;

                    myAdapter.Fill(ds, "ProductClass");
                }
            }

            return ds;
        }

        ///<summary>删除一条产品分类记录</summary>
        ///<param name="pc_id">产品分类Id</param>
        ///<returns>返回<c>true</c>删除成功，或<c>false</c>删除失败</returns>
        public static bool Delete(int pc_id)
        {
            int result = 0;
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_delete_single_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_pc_id", pc_id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        /// <summary>
        /// 修改产品分类记录
        /// </summary>
        /// <param name="myProductClass">myProductClass 模型</param>
        /// <returns>返回<c>true</c>修改成功,或<c>false</c>修改失败.</returns>
        public static bool Update(ProductClass myProductClass)
        {
            int result = 0;
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_update_single_item"))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_pc_id", myProductClass.PC_Id);
                    myCommand.Parameters.AddWithValue("_pc_name", myProductClass.PC_Name);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;

        }

        /// <summary>
        /// 插入产品分类记录
        /// </summary>
        /// <param name="myProductClass">myProductClass 模型</param>
        /// <returns>返回<c>true</c>插入成功，或<c>false</c>插入失败.</returns>
        public static bool Insert(ProductClass myProductClass)
        {
            int result = 0;
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_insert", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_pc_name", myProductClass.PC_Name);
                    if (myProductClass.Parent_Id > 0)
                    {
                        myCommand.Parameters.AddWithValue("_parent_id", myProductClass.Parent_Id);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_parent_id", DBNull.Value);
                    }
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;

        }

        public static List<int> GetParentClassList()
        {
            List<int> list = new List<int>();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_product_class_parent_class",myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using(MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                             while(reader.Read())
                             {
                                 list.Add(reader.GetInt32("parent_id"));
                             }
                        }
                        reader.Close();
                       
                    }
                }
            }

            return list;
        }

        #endregion



        #region Private Methods

        /// <summary>
        /// 初始化一个ProductClass类实体,并填充数据。
        /// </summary>
        private static ProductClass FillDataRecord(IDataRecord myDataRecord)
        {
            ProductClass myProductClass = new ProductClass();
            myProductClass.PC_Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PC_Id"));
            myProductClass.PC_Name = myDataRecord.GetString(myDataRecord.GetOrdinal("PC_Name"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Parent_Id")))
            {
                myProductClass.Parent_Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Parent_Id"));
            }
            myProductClass.PC_Order = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PC_Order"));

            return myProductClass;

        }

        #endregion
    }
}
