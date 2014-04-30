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
        public static ArticleCollection GetList(int ac_id, int startRowIndex, int maximumRows)
        {
            ArticleCollection tempList = new ArticleCollection();
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_select_list", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_ac_id", ac_id);
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
                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
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
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("sproc_article_search_list", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    if (istop)
                    {
                        myCommand.Parameters.AddWithValue("_istop", istop);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_istop", DBNull.Value);
                    }

                    if (iscommand)
                    {
                        myCommand.Parameters.AddWithValue("_iscommand", iscommand);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("_iscommand", DBNull.Value);
                    }

                    myConnection.Open();

                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
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

        public static ArticleCollection GetTop()
        {
            ArticleCollection list = new ArticleCollection();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_get_top",myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using(MySqlDataReader reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while(reader.Read())
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

        public static Article GetItem(int art_id)
        {
            Article myArticle = new Article();
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_select_item", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_art_id", art_id);
                    myConnection.Open();

                    using(MySqlDataReader myReader = myCommand.ExecuteReader())
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
            using (MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_delete_single_item", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_art_id", art_id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        public static bool Update(int art_id)
        {
            int result = 0;
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_update_single_click", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("_art_id", art_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }          
            }

            return result > 0;
        }

        public static bool Update(Article myArticle)
        {
            int result = 0;
            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_update_single_item", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_art_id", myArticle.art_id);
                    myCommand.Parameters.AddWithValue("_art_title", myArticle.art_title);
                    myCommand.Parameters.AddWithValue("_art_author", myArticle.art_author);
                    myCommand.Parameters.AddWithValue("_art_from", myArticle.art_from);
                    myCommand.Parameters.AddWithValue("_art_content", myArticle.art_content);
                    myCommand.Parameters.AddWithValue("_art_description", myArticle.art_description);
                    myCommand.Parameters.AddWithValue("_art_date", myArticle.art_date);
                    myCommand.Parameters.AddWithValue("_art_image", myArticle.art_image);
                    myCommand.Parameters.AddWithValue("_istop", myArticle.istop);
                    myCommand.Parameters.AddWithValue("_iscommend", myArticle.iscommend);
                    myCommand.Parameters.AddWithValue("_ac_id", myArticle.ac_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        public static bool Insert(Article myArticle)
        {
            int result = 0;

            using(MySqlConnection myConnection = new MySqlConnection(DbHelper.Connection))
            {
                using(MySqlCommand myCommand = new MySqlCommand("sproc_article_insert", myConnection))
                {
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("_art_title", myArticle.art_title);
                    myCommand.Parameters.AddWithValue("_art_author", myArticle.art_author);
                    myCommand.Parameters.AddWithValue("_art_from", myArticle.art_from);
                    myCommand.Parameters.AddWithValue("_art_content", myArticle.art_content);
                    myCommand.Parameters.AddWithValue("_art_description", myArticle.art_description);
                    myCommand.Parameters.AddWithValue("_art_date", myArticle.art_date);
                    myCommand.Parameters.AddWithValue("_art_image", myArticle.art_image);
                    myCommand.Parameters.AddWithValue("_art_click", myArticle.art_click);
                    myCommand.Parameters.AddWithValue("_istop", myArticle.istop);
                    myCommand.Parameters.AddWithValue("_iscommend", myArticle.iscommend);
                    myCommand.Parameters.AddWithValue("_ac_id", myArticle.ac_id);

                    myConnection.Open();

                    result = myCommand.ExecuteNonQuery();
                }
            }

            return result > 0;
        }

        #endregion

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
