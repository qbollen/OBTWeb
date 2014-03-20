using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data.SqlClient;
using System.Data;

namespace ORBITA.DAL
{
    /// <summary>
    /// Article Manage Service
    /// </summary>
    public static class ArticleService
    {
        #region public methods

        /// <summary>
        /// query article, all data
        /// </summary>
        /// <param name="ac_id"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="orderBy"></param>
        /// <returns>ArticleCollection include all data</returns>
        public static ArticleCollection GetList(int ac_id, int startRowIndex, int maximumRows, string orderBy)
        {
            ArticleCollection tempList = new ArticleCollection();
            using(SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("sprocArticleSelectList", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@ac_id", ac_id);
                    if (startRowIndex > 0 && maximumRows > 0)
                    {
                        myCommand.Parameters.AddWithValue("@startRowIndex", startRowIndex);
                        myCommand.Parameters.AddWithValue("@maximumRows", maximumRows);
                    }

                    if (!string.IsNullOrEmpty(orderBy))
                    {
                        myCommand.Parameters.AddWithValue("@orderBy", orderBy);
                    }

                    myConnection.Open();
                    using(SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ArticleCollection();
                            while(myReader.Read())
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

        /// <summary>
        /// query article with condition.
        /// </summary>
        /// <param name="istop"></param>
        /// <param name="iscommand"></param>
        /// <returns></returns>

        public static ArticleCollection GetList(bool istop, bool iscommand)
        {
            ArticleCollection tempList = new ArticleCollection();
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("sprocArticleSearchList", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    if (istop)
                    {
                        myCommand.Parameters.AddWithValue("@istop", istop);
                    }

                    if (iscommand)
                    {
                        myCommand.Parameters.AddWithValue("@iscommand", iscommand);
                    }

                    myConnection.Open();

                    using(SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new ArticleCollection();
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

        public static Article GetItem(int art_id)
        {
            Article myArticle = new Article();
            using(SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("sprocArticleSelectItem", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@art_id", art_id);
                    myConnection.Open();

                    using(SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            if (myReader.Read())
                            {
                                myArticle = FillDataRecord(myReader);
                            }
                        }
                    }
                }
            }

            return myArticle;
        }

        public static bool Delete(int art_id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("sprocArticleDeleteSingleItem", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@art_id", art_id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        public static bool Update(int art_id)
        {
            int result = 0;
            using(SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("aprocArticleUpdateSingleClick", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@art_id", art_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }          
            }

            return result > 0;
        }

        public static bool Update(Article myArticle)
        {
            int result = 0;
            using(SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("sprocArticleUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@art_id", myArticle.art_id);
                    myCommand.Parameters.AddWithValue("@art_title", myArticle.art_title);
                    myCommand.Parameters.AddWithValue("@art_author", myArticle.art_author);
                    myCommand.Parameters.AddWithValue("@art_from", myArticle.art_from);
                    myCommand.Parameters.AddWithValue("@art_content", myArticle.art_content);
                    myCommand.Parameters.AddWithValue("@art_description", myArticle.art_description);
                    myCommand.Parameters.AddWithValue("@art_date", myArticle.art_date);
                    myCommand.Parameters.AddWithValue("@art_image", myArticle.art_image);
                    myCommand.Parameters.AddWithValue("@istop", myArticle.istop);
                    myCommand.Parameters.AddWithValue("@iscommend", myArticle.iscommend);
                    myCommand.Parameters.AddWithValue("@ac_id", myArticle.ac_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        public static bool Insert(Article myArticle)
        {
            int result = 0;

            using(SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using(SqlCommand myCommand = new SqlCommand("sprocArticleInsert", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@art_title", myArticle.art_title);
                    myCommand.Parameters.AddWithValue("@art_author", myArticle.art_author);
                    myCommand.Parameters.AddWithValue("@art_from", myArticle.art_from);
                    myCommand.Parameters.AddWithValue("@art_content", myArticle.art_content);
                    myCommand.Parameters.AddWithValue("@art_description", myArticle.art_description);
                    myCommand.Parameters.AddWithValue("@art_date", myArticle.art_date);
                    myCommand.Parameters.AddWithValue("@art_image", myArticle.art_image);
                    myCommand.Parameters.AddWithValue("@art_click", myArticle.art_click);
                    myCommand.Parameters.AddWithValue("@istop", myArticle.istop);
                    myCommand.Parameters.AddWithValue("@iscommend", myArticle.iscommend);
                    myCommand.Parameters.AddWithValue("@ac_id", myArticle.ac_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        #region private methods

        private static Article FillDataRecord(IDataRecord myDataRecord)
        {
            Article myArticle = new Article();

            myArticle.art_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("art_id"));


            myArticle.art_title = myDataRecord.GetString(myDataRecord.GetOrdinal("art_title"));
            myArticle.art_content = myDataRecord.GetString(myDataRecord.GetOrdinal("art_content"));
            myArticle.art_date = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("art_date"));
            myArticle.ac_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ac_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("art_author")))
            {
                myArticle.art_author = myDataRecord.GetString(myDataRecord.GetOrdinal("art_author"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("art_from")))
            {
                myArticle.art_from = myDataRecord.GetString(myDataRecord.GetOrdinal("art_from"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("art_description")))
            {
                myArticle.art_description = myDataRecord.GetString(myDataRecord.GetOrdinal("art_description"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("art_image")))
            {
                myArticle.art_image = myDataRecord.GetString(myDataRecord.GetOrdinal("art_image"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("art_click")))
            {
                myArticle.art_click = myDataRecord.GetInt32(myDataRecord.GetOrdinal("art_click"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("istop")))
            {
                myArticle.istop = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("istop"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("iscommend")))
            {
                myArticle.iscommend = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("iscommend"));
            }
            return myArticle;
        }

        #endregion
    }
}
