using ORBITA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ORBITA.DAL
{
    public static class ArticleClassService
    {
        #region Public Methods

        /// <summary>查询文章分类 所有数据</summary>
        /// <returns>ArticleClassCollection 包含所有记录.</returns>
        public static ArticleClassCollection GetList()
        {
            ArticleClassCollection tempList = new ArticleClassCollection();
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ArticleClassCollection();
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


        /// <summary>条件查询文章分类 </summary>
        /// <param name="parent_id">父亲ID</param>
        /// <returns>ArticleClassCollection 包含条件查询的记录.</returns>
        public static ArticleClassCollection GetListByParentID(int parent_id)
        {
            ArticleClassCollection tempList = new ArticleClassCollection();
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassSelectListByParentID", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (parent_id > 0)
                    {
                        myCommand.Parameters.AddWithValue("@parent_id", parent_id);
                    }
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ArticleClassCollection();
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


        /// <summary>条件查询文章分类 </summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>ArticleClass模型 包含一条文章分类记录.</returns>
        public static ArticleClass GetItem(int ac_id)
        {
            ArticleClass myArticleClass = new ArticleClass();
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassSelectItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@ac_id", ac_id);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                myArticleClass = FillDataRecord(myReader);
                            }
                        }
                    }
                }
            }
            return myArticleClass;
        }


        /// <summary>查询文章分类树 </summary>
        /// <returns>DataSet 包含文章分类树记录.</returns>
        public static DataSet GetTree()
        {
            DataSet ds = new DataSet();
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlDataAdapter myAdapter = new SqlDataAdapter())
                {
                    SqlCommand myCommand = new SqlCommand("sprocArticleClassGetTree", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myAdapter.SelectCommand = myCommand;

                    myAdapter.Fill(ds, "ArticleClass");
                }
            }
            return ds;
        }






        /// <summary>删除一条文章分类记录</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>返回 <c>true</c> 删除成功, 或 <c>false</c> 删除失败.</returns>
        public static bool Delete(int ac_id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassDeleteSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@ac_id", ac_id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }


        /// <summary>修改文章分类记录</summary>
        /// <param name="myArticleClass">myArticleClass 模型</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        public static bool Update(ArticleClass myArticleClass)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@ac_id", myArticleClass.ac_id);
                    myCommand.Parameters.AddWithValue("@ac_name", myArticleClass.ac_name);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }


        /// <summary>插入文章分类记录</summary>
        /// <param name="myArticleClass">myArticleClass 模型</param>
        /// <returns>返回 <c>true</c> 插入成功, 或 <c>false</c> 插入失败.</returns>
        public static bool Insert(ArticleClass myArticleClass)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(DbHelper.Connection))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleClassInsert", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@ac_name", myArticleClass.ac_name);
                    if (myArticleClass.parent_id > 0)
                    {
                        myCommand.Parameters.AddWithValue("@parent_id", myArticleClass.parent_id);
                    }

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 初始化一个ArticleClass类实体，并填充数据。
        /// </summary>
        private static ArticleClass FillDataRecord(IDataRecord myDataRecord)
        {

            ArticleClass myArticleClass = new ArticleClass();

            myArticleClass.ac_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ac_id"));
            myArticleClass.ac_name = myDataRecord.GetString(myDataRecord.GetOrdinal("ac_name"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("parent_id")))
            {
                myArticleClass.parent_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("parent_id"));
            }

            myArticleClass.ac_order = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ac_order"));


            return myArticleClass;
        }

        #endregion
    }
}
