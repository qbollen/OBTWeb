using ORBITA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

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
            string sql = "SELECT * FROM t_articleclass";

            MySqlDataReader myReader = DbHelper.ExecuteDataReader(sql);
                  
            if (myReader.HasRows)
            {
                tempList = new ArticleClassCollection();
                while (myReader.Read())
                {
                    tempList.Add(FillDataRecord(myReader));
                }
            }
            myReader.Close();
      
            return tempList;
        }


        /// <summary>条件查询文章分类 </summary>
        /// <param name="parent_id">父亲ID</param>
        /// <returns>ArticleClassCollection 包含条件查询的记录.</returns>
        public static ArticleClassCollection GetListByParentID(int parent_id)
        {
            ArticleClassCollection tempList = new ArticleClassCollection();
            string sql;

            MySqlParameter[] parms = null;

            if(parent_id > 0)
            {
                sql = "SELECT * FROM t_articleclass WHERE parent_id = ?parent_id ORDER BY ac_order, ac_id";
                parms = new MySqlParameter[] { new MySqlParameter("?parent_id", MySqlDbType.Int32)};
                parms[0].Value = parent_id;
            }
            else
            {
                sql = "SELECT * FROM t_articleclass WHERE parent_id IS NULL ORDER BY ac_order, ac_id";
            }

            MySqlDataReader myReader = DbHelper.ExecuteDataReader(sql, parms);
            
            if (myReader.HasRows)
            {
                tempList = new ArticleClassCollection();
                while (myReader.Read())
                {
                    tempList.Add(FillDataRecord(myReader));
                }
            }
            myReader.Close();

            return tempList;
        }


        /// <summary>条件查询文章分类 </summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>ArticleClass模型 包含一条文章分类记录.</returns>
        public static ArticleClass GetItem(int ac_id)
        {
            ArticleClass myArticleClass = new ArticleClass();
            string sql = "SELECT * FROM t_articleclass WHERE ac_id = ?ac_id";
            MySqlParameter[] parms = { new MySqlParameter("?ac_id", MySqlDbType.Int32) };
            parms[0].Value = ac_id;

            MySqlDataReader myReader = DbHelper.ExecuteDataReader(sql, parms);
              
            if (myReader.HasRows)
            {
                if (myReader.Read())
                {
                    myArticleClass = FillDataRecord(myReader);
                }
            }

            myReader.Close();
                                     
            return myArticleClass;
        }


        /// <summary>查询文章分类树 </summary>
        /// <returns>DataSet 包含文章分类树记录.</returns>
        public static DataSet GetTree()
        {
            string sql = @"SELECT ac_id, ac_name, parent_id, 0 as depth, 
				right('0000' + cast(ac_order as char(255)), 4) as sort
		        FROM t_articleclass
		        WHERE parent_id is null 
		        UNION ALL
		        SELECT a.ac_id, a.ac_name, a.parent_id, depth + 1, 
				concat(sort, ', ', right(concat('0000', cast(a.ac_order as char(255))), 4)) as sort
		        FROM t_articleclass a
			    INNER JOIN (SELECT ac_id, ac_name, parent_id, 0 as depth, 
				right('0000' + cast(ac_order as char(255)), 4) as sort
				FROM t_articleclass
				WHERE parent_id is null) t
		 	    ON a.parent_id = t.ac_id 
		        ORDER BY sort";
            return DbHelper.ExecuteDataSet(sql, "ArticleClass");
        }   

        /// <summary>删除一条文章分类记录</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>返回 <c>true</c> 删除成功, 或 <c>false</c> 删除失败.</returns>
        public static bool Delete(int ac_id)
        {
            int result = 0;
            int? parent_id = null;
            int order = 0;
            int acid, acorder;
            string sql = "SELECT parent_id FROM t_articleclass WHERE ac_id = ?ac_id";
            MySqlParameter[] parms = { new MySqlParameter("?ac_id", MySqlDbType.Int32)};
            parms[0].Value = ac_id;
            parent_id = DbHelper.ExecuteScalar(sql, parms) as int?;

            sql = "DELETE FROM t_articleclass WHERE ac_id = ?ac_id";
            MySqlParameter[] parms2 = { new MySqlParameter("?ac_id", MySqlDbType.Int32)};
            parms2[0].Value = ac_id;
            result = DbHelper.ExecuteNonQuery(sql, parms2);

            if (result != 0)
            {
                //重置pc_order
                MySqlParameter[] parms3 = null;
                if (parent_id == null)
                {
                    sql = "select ac_id,ac_order from T_ArticleClass where parent_id is null order by ac_order";
                }
                else
                {
                    sql = "select ac_id,ac_order from T_ArticleClass where parent_id=?parent_id order by ac_order";
                    parms3 = new MySqlParameter[] { new MySqlParameter("?parent_id", MySqlDbType.Int32) };
                    parms3[0].Value = parent_id;
                }

                order = 0;

                MySqlDataReader reader = DbHelper.ExecuteDataReader(sql, parms3);
                while (reader.Read())
                {
                    acid = reader.GetInt32(reader.GetOrdinal("ac_id"));
                    acorder = reader.GetInt32(reader.GetOrdinal("ac_order"));

                    order = order + 1;

                    sql = "update T_ArticleClass set ac_order = ?ac_order where ac_id = ?ac_id";
                    MySqlParameter[] params3 = { new MySqlParameter("?ac_order",MySqlDbType.Int32),
                                                 new MySqlParameter("?ac_id",MySqlDbType.Int32)
                                               };
                    params3[0].Value = order;
                    params3[1].Value = acid;
                    DbHelper.ExecuteNonQuery(sql, params3);
                }

                reader.Close();
            }

            return result > 0;
        }


        /// <summary>修改文章分类记录</summary>
        /// <param name="myArticleClass">myArticleClass 模型</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        public static bool Update(ArticleClass myArticleClass)
        {
            int result = 0;
            string sql = "	UPDATE t_articleclass SET ac_name = ?ac_name WHERE ac_id = ?ac_id";
            MySqlParameter[] parms = { 
                                        new MySqlParameter("?ac_name", MySqlDbType.VarChar),
                                        new MySqlParameter("?ac_id", MySqlDbType.Int32)
                                     };

            parms[0].Value = myArticleClass.ac_name;
            parms[1].Value = myArticleClass.ac_id;

            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }


        /// <summary>插入文章分类记录</summary>
        /// <param name="myArticleClass">myArticleClass 模型</param>
        /// <returns>返回 <c>true</c> 插入成功, 或 <c>false</c> 插入失败.</returns>
        public static bool Insert(ArticleClass myArticleClass)
        {
            int result = 0;
            int? parent_id = null;
            int ac_order;
            string sql1, sql2;

            if (myArticleClass.parent_id > 0)
            {
                parent_id = myArticleClass.parent_id;
            }

            MySqlParameter[] parms = null;
            if (parent_id == null)
            {
                sql1 = "select count(*) from T_ArticleClass where parent_id is null";
            }
            else
            {
                sql1 = "select count(*) from T_ArticleClass where parent_id = ?Parent_id";
                parms = new MySqlParameter[] { 
                    new MySqlParameter("?Parent_id",MySqlDbType.Int32),
                };
                parms[0].Value = parent_id;
            }

            ac_order = Convert.ToInt32(DbHelper.ExecuteScalar(sql1, parms));


            MySqlParameter[] params2 = null;
            if (parent_id == null)
            {
                sql2 = "insert into T_ArticleClass(ac_name,ac_order) values (?ac_name,?ac_order)";
                params2 = new MySqlParameter[]{ 
                                          new MySqlParameter("?ac_name",MySqlDbType.VarChar),
                                          new MySqlParameter("?ac_order",MySqlDbType.Int32)
                                       };
                params2[0].Value = myArticleClass.ac_name;
                params2[1].Value = ac_order + 1;
            }
            else
            {
                sql2 = "insert into T_ArticleClass(ac_name,parent_id,ac_order) values (?ac_name,?parent_id,?ac_order)";
                params2 = new MySqlParameter[]{ 
                                          new MySqlParameter("?ac_name",MySqlDbType.VarChar),
                                          new MySqlParameter("?parent_id",MySqlDbType.Int32),
                                          new MySqlParameter("?ac_order",MySqlDbType.Int32)
                                       };
                params2[0].Value = myArticleClass.ac_name;
                params2[1].Value = parent_id;
                params2[2].Value = ac_order + 1;

            }

            result = DbHelper.ExecuteNonQuery(sql2, params2);

            return result > 0;
        }


        public static List<int> GetParentClassList()
        {
            List<int> list = new List<int>();
            string sql = "SELECT parent_id FROM t_articleclass WHERE parent_id IS NOT NULL GROUP BY parent_id ORDER BY parent_id";

            MySqlDataReader reader = DbHelper.ExecuteDataReader(sql);
                    
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    list.Add(reader.GetInt32("parent_id"));
                }
            }
            reader.Close();
                                       
            return list;
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
