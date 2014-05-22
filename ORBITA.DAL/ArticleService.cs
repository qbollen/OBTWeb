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
            int iStartRowIndex = -1;
            int iMaximumRows = -1;

            if (startRowIndex > 0 && maximumRows > 0)
            {
                iStartRowIndex = startRowIndex;
                iMaximumRows = maximumRows;
            }

            ArticleCollection tempList = new ArticleCollection();
            string sql = @"SELECT
							*
	                        FROM 
                            (
                                select 
                                   *, (select ifnull(sum(1) + 1, 1) 
                                        from t_article 
                                        where (?ac_id=0 or ac_id=?ac_id) and art_id > a.art_id) as row_rank
                                from t_article a 
                                where 
                                ?ac_id=0
                                or
                                ac_id in (select ac_id from (select ac_id from t_articleclass where ac_id=?ac_id
                                                         union all
                                                         select p.ac_id 
                                                         from t_articleclass p 
                                                         inner join
                                                         (select ac_id
                                                         from t_articleclass
                                                         where ac_id=?ac_id) t on p.parent_id = t.ac_id) as temp) 
                                order by art_id desc
                            ) 
                            as ArticleWithRowNumbers
                            where 
                            ((row_rank between ?start_row_index AND ?start_row_index + ?maximum_rows - 1)
			                            OR ?start_row_index = -1 OR ?maximum_rows = -1)";

            MySqlParameter[] parms = {
                                         new MySqlParameter("?ac_id",MySqlDbType.Int32),
                                         new MySqlParameter("?start_row_index",MySqlDbType.Int32),
                                         new MySqlParameter("?maximum_rows",MySqlDbType.Int32)
                                     };
            parms[0].Value = ac_id;
            parms[1].Value = iStartRowIndex;
            parms[2].Value = iMaximumRows;

            
            MySqlDataReader myReader = DbHelper.ExecuteDataReader(sql, parms);
                 
            if (myReader.HasRows)
            {
                tempList = new ArticleCollection();
                while(myReader.Read())
                {
                    tempList.Add(FillDataRecord(myReader));
                }
            }

             myReader.Close();
                   
            return tempList;
        }

        /// <summary>
        /// query article with condition.
        /// </summary>
        /// <param name="istop"></param>
        /// <param name="iscommand"></param>
        /// <returns></returns>

        public static ArticleCollection GetList(bool istop, bool iscommend)
        {
            bool bIsTop = false;
            bool bIsCommend = false;

            if (istop)
            {
                bIsTop = istop;
            }
            if (iscommend)
            {
                bIsCommend = iscommend;
            }

            ArticleCollection tempList = new ArticleCollection();

            string sql = "select * from T_Article where IsTop=?IsTop and IsCommend=?IsCommend";

            MySqlParameter[] parms = { 
                                        new MySqlParameter("?IsTop", MySqlDbType.Bit),
                                        new MySqlParameter("?IsCommend", MySqlDbType.Bit)
                                     };

            parms[0].Value = bIsTop;
            parms[0].Value = bIsCommend;

            MySqlDataReader reader = DbHelper.ExecuteDataReader(sql, parms);

            if (reader.HasRows)
            {
                tempList = new ArticleCollection();
                while (reader.Read())
                {
                    tempList.Add(FillDataRecord(reader));
                }
            }

            reader.Close();
                    
            return tempList;
        }

        public static ArticleCollection GetTop()
        {
            ArticleCollection list = new ArticleCollection();
            string sql = @"SELECT * FROM t_article ORDER BY art_id DESC LIMIT 3;";

            MySqlDataReader reader = DbHelper.ExecuteDataReader(sql);
                
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();            
             
            return list;
        }

        public static Article GetItem(int art_id)
        {
            Article myArticle = new Article();
            string sql = @"SELECT * FROM t_article WHERE art_id = ?art_id;";	                 
            
            MySqlParameter[] parms = {
                                        new MySqlParameter("?art_id", MySqlDbType.Int32)
                                     };

            parms[0].Value = art_id;
    
            MySqlDataReader myReader = DbHelper.ExecuteDataReader(sql,parms);
                    
            if (myReader.HasRows)
            {
                if (myReader.Read())
                {
                    myArticle = FillDataRecord(myReader);
                }
            }

            myReader.Close();
                                       
            return myArticle;
        }

        public static bool Delete(int art_id)
        {
            int result = 0;
            string sql = "DELETE FROM t_article WHERE art_id = ?art_id;";
            MySqlParameter[] parms = { 
                                        new MySqlParameter("?art_id", MySqlDbType.Int32)
                                     };
            parms[0].Value = art_id;

            result = DbHelper.ExecuteNonQuery(sql, parms);
         
            return result > 0;
        }

        public static bool Update(int art_id)
        {
            int result = 0;
            string sql = "UPDATE t_article SET art_click = art_click + 1 WHERE art_id = ?art_id";
            MySqlParameter[] parms = { 
                                        new MySqlParameter("?art_id", MySqlDbType.Int32)
                                     };
            parms[0].Value = art_id;

            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        public static bool Update(Article myArticle)
        {
            int result = 0;
            string sql = @"UPDATE 
		                    t_article
	                        SET
		                        art_title = ?art_title, 
		                        art_author = ?art_author, 
		                        art_from = ?art_from, 
		                        art_content = ?art_content, 
		                        art_description = ?art_description, 
		                        art_image = ?art_image, 
		                        art_date = ?art_date, 
		                        istop = ?istop, 
		                        iscommend = ?iscommend, 
		                        ac_id = ?ac_id
	                        WHERE
		                        art_id = ?art_id;";

            MySqlParameter[] parms = { 
                                        new MySqlParameter("?art_title",MySqlDbType.VarChar),
                                        new MySqlParameter("?art_author",MySqlDbType.VarChar),
                                        new MySqlParameter("?art_from",MySqlDbType.VarChar),
                                        new MySqlParameter("?art_content",MySqlDbType.Text),
                                        new MySqlParameter("?art_description",MySqlDbType.Text),
                                        new MySqlParameter("?art_image",MySqlDbType.VarChar),
                                        new MySqlParameter("?art_date",MySqlDbType.DateTime),
                                        new MySqlParameter("?istop", MySqlDbType.Bit),
                                        new MySqlParameter("?iscommend", MySqlDbType.Bit),
                                        new MySqlParameter("?ac_id", MySqlDbType.Int32),
                                        new MySqlParameter("?art_id", MySqlDbType.Int32)
            };

                    
            parms[0].Value = myArticle.art_title;
            parms[1].Value = myArticle.art_author;
            parms[2].Value = myArticle.art_from;
            parms[3].Value = myArticle.art_content;
            parms[4].Value = myArticle.art_description;
            parms[5].Value = myArticle.art_image;
            parms[6].Value = myArticle.art_date;                 
            parms[7].Value = myArticle.istop;
            parms[8].Value = myArticle.iscommend;
            parms[9].Value = myArticle.ac_id;
            parms[10].Value = myArticle.art_id;

            result = DbHelper.ExecuteNonQuery(sql, parms);
         
            return result > 0;
        }

        public static bool Insert(Article myArticle)
        {
            int result = 0;
            string sql = @"INSERT INTO
		                    t_article
		                    (
			                    art_title, 
			                    art_author, 
			                    art_from, 
			                    art_content, 
			                    art_description, 
			                    art_image, 
			                    art_date,
			                    art_click,
			                    istop, 
			                    iscommend, 
			                    ac_id
		                    )
	                    VALUES
		                    (
			                    ?art_title, 
			                    ?art_author, 
			                    ?art_from, 
			                    ?art_content, 
			                    ?art_description, 
			                    ?art_image, 
			                    ?art_date,
			                    ?art_click,
			                    ?istop, 
			                    ?iscommend, 
			                    ?ac_id
		                    )";

            MySqlParameter[] parms = { 
                                        new MySqlParameter("?art_title", MySqlDbType.VarChar),
                                        new MySqlParameter("?art_author", MySqlDbType.VarChar),
                                        new MySqlParameter("?art_from", MySqlDbType.VarChar),
                                        new MySqlParameter("?art_content", MySqlDbType.Text),
                                        new MySqlParameter("?art_description", MySqlDbType.Text),
                                        new MySqlParameter("?art_image", MySqlDbType.VarChar),
                                        new MySqlParameter("?art_date", MySqlDbType.DateTime),
                                        new MySqlParameter("?art_click", MySqlDbType.Int32),
                                        new MySqlParameter("?istop", MySqlDbType.Bit),
                                        new MySqlParameter("?iscommend", MySqlDbType.Bit),
                                        new MySqlParameter("?ac_id", MySqlDbType.Int32)
                                     };

            parms[0].Value = myArticle.art_title;
            parms[1].Value = myArticle.art_author;
            parms[2].Value = myArticle.art_from;
            parms[3].Value = myArticle.art_content;
            parms[4].Value = myArticle.art_description;
            parms[5].Value = myArticle.art_image;
            parms[6].Value = myArticle.art_date;                   
            parms[7].Value = myArticle.art_click;
            parms[8].Value = myArticle.istop;
            parms[9].Value = myArticle.iscommend;
            parms[10].Value = myArticle.ac_id;
               
            result = DbHelper.ExecuteNonQuery(sql, parms);
           
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
