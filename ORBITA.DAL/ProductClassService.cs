using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data;
using System.Data.OleDb;

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
        public static ProductClassCollection GetList
            ()
        {
            ProductClassCollection list = null;
            string sql = "SELECT * FROM T_ProductClass";
            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql);
            if (reader.HasRows)
            {
                list = new ProductClassCollection();
                while (reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();

            return list;
        }

        ///<summary>条件查询产品分类</summary>
        ///<param name="parent_id">父亲ID 没有传 null</param>
        ///<returns>ProductClassCollection包含条件查询的记录</returns>
        public static ProductClassCollection GetListByParentId(int parent_id)
        {
            string sql;
            ProductClassCollection list = new ProductClassCollection();

            OleDbParameter[] parms = null;

            if (parent_id > 0)
            {
                sql = "SELECT * FROM T_ProductClass WHERE Parent_Id=@Parent_Id ORDER BY PC_Order, PC_Id";
                parms = new OleDbParameter[] { new OleDbParameter("@Parent_Id", OleDbType.Integer) };
                parms[0].Value = parent_id;
                
            }
            else
            {
                sql = "SELECT * FROM T_ProductClass WHERE Parent_Id IS NULL ORDER BY PC_Order, PC_Id";
            }

            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();

            return list;

        }

        ///<summary>条件查询产品分类</summary>
        ///<param name="pc_id">产品分类Id</param>
        ///<returns>ProductClass模型 包含一条产品分类记录.</returns>
        public static ProductClass GetItem(int pc_id)
        {
            ProductClass myProductClass = new ProductClass();
            string sql = "SELECT * FROM T_ProductClass WHERE PC_Id=@PC_Id";
            OleDbParameter[] parms = { new OleDbParameter("@PC_Id", OleDbType.Integer) };
            parms[0].Value = pc_id;
            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    myProductClass = FillDataRecord(reader);
                }
            }

            reader.Close();

            return myProductClass;

        }

        ///<summary>查询产品分类树</summary>
        ///<returns>DataSet 包含产品分类树记录.</returns>
        public static DataSet GetTree()
        {
            string sql = @"select pc_id, pc_name, parent_id, 0 as depth,right('0000' + Cstr(pc_order),4) 
                         as sort from T_ProductClass where Parent_Id is null union all 
                         select p.pc_id,p.pc_name,p.parent_id,depth+1,sort + ',' + right('0000' + Cstr(p.pc_order),4) 
                         from T_ProductClass p inner join (select pc_id, pc_name, parent_id, 0 as depth,right('0000' + Cstr(pc_order),4) as sort 
                         from T_ProductClass where Parent_Id is null) t on p.Parent_Id = t.pc_id order by sort";
            return DbHelper.ExecuteDataSet(sql,"T_ProductClass");

        }

        ///<summary>删除一条产品分类记录</summary>
        ///<param name="pc_id">产品分类Id</param>
        ///<returns>返回<c>true</c>删除成功，或<c>false</c>删除失败</returns>
        public static bool Delete(int pc_id)
        {
            int result = 0;
            int? parent_id = null;
            int order = 0;
            int pcid, pcorder;
            string sql = "select parent_id from T_ProductClass where pc_id=@pc_id";
            OleDbParameter[] parms = { new OleDbParameter("@pc_id", OleDbType.Integer) };
            parms[0].Value = pc_id;
            parent_id = DbHelper.ExecuteScalar(sql, parms) as int?;

            sql = "delete from T_ProductClass where pc_id=@pc_id";
            OleDbParameter[] parms2 = { new OleDbParameter("@pc_id",OleDbType.Integer) };
            parms2[0].Value = pc_id;
            result = DbHelper.ExecuteNonQuery(sql, parms2);

            if (result != 0)
            {
                //重置pc_order
                OleDbParameter[] parms3 = null;
                if (parent_id == null)
                {
                    sql = "select pc_id,pc_order from T_ProductClass where parent_id is null order by pc_order";
                }
                else
                {
                    sql = "select pc_id,pc_order from T_ProductClass where parent_id=@parent_id order by pc_order";
                    parms3 = new OleDbParameter[] { new OleDbParameter("@parent_id", OleDbType.Integer) };
                    parms3[0].Value = parent_id;
                }

                order = 0;

                OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms3);
                while (reader.Read())
                {
                    pcid = reader.GetInt32(reader.GetOrdinal("pc_id"));
                    pcorder = reader.GetInt32(reader.GetOrdinal("pc_order"));

                    order = order + 1;

                    sql = "update T_ProductClass set pc_order = @pc_order where pc_id = @pc_id";
                    OleDbParameter[] params3 = { new OleDbParameter("@pc_order",OleDbType.Integer),
                                                 new OleDbParameter("@pc_id",OleDbType.Integer)
                                               };
                    params3[0].Value = order;
                    params3[1].Value = pcid;
                    DbHelper.ExecuteNonQuery(sql, params3);
                }

                reader.Close();
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
            string sql = "update T_ProductClass set pc_name = @pc_name where pc_id = @pc_id";
            OleDbParameter[] parms = { 
                                        new OleDbParameter("@pc_name",OleDbType.VarWChar),
                                        new OleDbParameter("@pc_id",OleDbType.Integer)
                                     };
            parms[0].Value = myProductClass.PC_Name;
            parms[1].Value = myProductClass.PC_Id;
            result = DbHelper.ExecuteNonQuery(sql, parms);

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
            int? parent_id = null;
            int pc_order;
            string sql1,sql2;

            if (myProductClass.Parent_Id > 0)
            {
                parent_id = myProductClass.Parent_Id;
            }

            OleDbParameter[] parms = null;
            if (parent_id == null)
            {
                sql1 = "select count(*) from T_ProductClass where parent_id is null";
            }
            else
            {
                sql1 = "select count(*) from T_ProductClass where parent_id = @Parent_id";
                parms = new OleDbParameter[] { 
                    new OleDbParameter("@Parent_id",OleDbType.Integer),
                };
                parms[0].Value = parent_id;
            }

            pc_order = Convert.ToInt32(DbHelper.ExecuteScalar(sql1, parms));


            OleDbParameter[] params2 = null;
            if (parent_id == null)
            {
                sql2 = "insert into T_ProductClass(pc_name,pc_order) values (@pc_name,@pc_order)";
                params2 = new OleDbParameter[]{ 
                                          new OleDbParameter("@pc_name",OleDbType.VarWChar),
                                          new OleDbParameter("@pc_order",OleDbType.Integer)
                                       };
                params2[0].Value = myProductClass.PC_Name;
                params2[1].Value = pc_order + 1;
            }
            else
            {
                sql2 = "insert into T_ProductClass(pc_name,parent_id,pc_order) values (@pc_name,@parent_id,@pc_order)";
                params2 = new OleDbParameter[]{ 
                                          new OleDbParameter("@pc_name",OleDbType.VarWChar),
                                          new OleDbParameter("@parent_id",OleDbType.Integer),
                                          new OleDbParameter("@pc_order",OleDbType.Integer)
                                       };
                params2[0].Value = myProductClass.PC_Name;
                params2[1].Value = parent_id;
                params2[2].Value = pc_order + 1;

            }

            result = DbHelper.ExecuteNonQuery(sql2, params2);

            return result > 0;

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
