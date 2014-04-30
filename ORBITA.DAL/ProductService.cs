using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data.OleDb;
using System.Data;
using MySql.Data.MySqlClient;

namespace ORBITA.DAL
{
    /// <summary>
    /// 产品管理 DAL
    /// </summary>
    public class ProductService
    {
        #region Public Methods

        /// <summary>查询产品 所有数据</summary>
        /// <returns>ProductCollection 包含所有记录.</returns>
        public static ProductCollection GetList(int pc_id, int startRowIndex, int maximumRows)
        {
            ProductCollection tempList = new ProductCollection();
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_select_list", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_pc_id", pc_id);

                    if (startRowIndex > 0 && maximumRows > 0)
                    {
                        myCommand.Parameters.AddWithValue("_start_row_index", startRowIndex);
                        myCommand.Parameters.AddWithValue("_maximum_rows", maximumRows);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_start_row_index", -1);
                        myCommand.Parameters.AddWithValue("_maximum_rows", -1);
                    }
                    myConnection.Open();
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ProductCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }



        /// <summary>条件查询产品 </summary>
        /// <param name="istop">置顶</param>
        /// <param name="iscommend">推荐</param>
        /// <returns>ProductCollection 包含条件查询的记录.</returns>
        public static ProductCollection GetList(bool istop, bool iscommend)
        {
            ProductCollection tempList = new ProductCollection();
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_select_list_by_istop_iscommend", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_istop", istop);

                    myCommand.Parameters.AddWithValue("_iscommend", iscommend);


                    myConnection.Open();
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ProductCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }

        public static ProductCollection GetCommend()
        {
            ProductCollection list = new ProductCollection();
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_get_commend", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using (MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(FillDataRecord(reader));
                            }

                        }
                        reader.Close();
                    }
                }
            }
            return list;
        }


        /// <summary>条件查询产品 </summary>
        /// <param name="prod_id">产品ID</param>
        /// <returns>Product模型 包含一条产品记录.</returns>
        public static Product GetItem(int prod_id)
        {
            Product myProduct = new Product();
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_select_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_prod_id", prod_id);
                    myConnection.Open();
                    using (MySqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                myProduct = FillDataRecord(myReader);
                            }
                        }

                        myReader.Close();
                    }
                }
            }
            return myProduct;
        }

        /// <summary>删除一条产品记录</summary>
        /// <param name="prod_id">产品ID</param>
        /// <returns>返回 <c>true</c> 删除成功, 或 <c>false</c> 删除失败.</returns>
        public static bool Delete(int prod_id)
        {
            int result = 0;
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_delete_single_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_prod_id", prod_id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }


        /// <summary>修改产品点击数</summary>
        /// <param name="prod_id">产品ID</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        public static bool Update(int prod_id)
        {
            int result = 0;
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_update_single_click", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_prod_id", prod_id);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }


        /// <summary>修改产品</summary>
        /// <param name="myProduct">产品模型</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        public static bool Update(Product myProduct)
        {
            int result = 0;
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_update_single_item", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_prod_id", myProduct.Prod_Id);
                    myCommand.Parameters.AddWithValue("_prod_name", myProduct.Prod_Name);
                    myCommand.Parameters.AddWithValue("_prod_number", myProduct.Prod_Number);
                    myCommand.Parameters.AddWithValue("_prod_price", myProduct.Prod_Price);
                    myCommand.Parameters.AddWithValue("_prod_image", myProduct.Prod_Image);
                    myCommand.Parameters.AddWithValue("_prod_content", myProduct.Prod_Content);
                    myCommand.Parameters.AddWithValue("_prod_date", myProduct.Prod_Date);
                    myCommand.Parameters.AddWithValue("_prod_click", myProduct.Prod_Click);
                    myCommand.Parameters.AddWithValue("_istop", myProduct.IsTop);
                    myCommand.Parameters.AddWithValue("_iscommend", myProduct.IsCommend);
                    myCommand.Parameters.AddWithValue("_pc_id", myProduct.Pc_Id);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }


        /// <summary>插入产品记录</summary>
        /// <param name="myProduct">myProduct 模型</param>
        /// <returns>返回 <c>true</c> 插入成功, 或 <c>false</c> 插入失败.</returns>
        public static bool Insert(Product myProduct)
        {
            int result = 0;
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_product_insert", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_prod_name", myProduct.Prod_Name);
                    myCommand.Parameters.AddWithValue("_prod_number", myProduct.Prod_Number);
                    myCommand.Parameters.AddWithValue("_prod_price", myProduct.Prod_Price);
                    myCommand.Parameters.AddWithValue("_prod_image", myProduct.Prod_Image);
                    myCommand.Parameters.AddWithValue("_prod_content", myProduct.Prod_Content);
                    myCommand.Parameters.AddWithValue("_prod_date", myProduct.Prod_Date);
                    myCommand.Parameters.AddWithValue("_prod_click", myProduct.Prod_Click);
                    myCommand.Parameters.AddWithValue("_istop", myProduct.IsTop);
                    myCommand.Parameters.AddWithValue("_iscommend", myProduct.IsCommend);
                    myCommand.Parameters.AddWithValue("_pc_id", myProduct.Pc_Id);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        #endregion

        #region Private Methods

        private static Product FillDataRecord(IDataRecord myDataRecord)
        {
            Product myProduct = new Product();

            myProduct.Prod_Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("prod_id"));
            myProduct.Prod_Name = myDataRecord.GetString(myDataRecord.GetOrdinal("prod_name"));
            myProduct.Prod_Content = myDataRecord.GetString(myDataRecord.GetOrdinal("prod_content"));
            myProduct.Prod_Date = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("prod_date"));
            myProduct.Pc_Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("pc_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("prod_number")))
            {
                myProduct.Prod_Number = myDataRecord.GetString(myDataRecord.GetOrdinal("prod_number"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("prod_price")))
            {
                myProduct.Prod_Price = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("prod_price"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("prod_image")))
            {
                myProduct.Prod_Image = myDataRecord.GetString(myDataRecord.GetOrdinal("prod_image"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("prod_click")))
            {
                myProduct.Prod_Click = myDataRecord.GetInt32(myDataRecord.GetOrdinal("prod_click"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("istop")))
            {
                myProduct.IsTop = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("istop"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("iscommend")))
            {
                myProduct.IsCommend = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("iscommend"));
            }

            return myProduct;
        }

        #endregion
    }
}
