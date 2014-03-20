using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.Data.OleDb;
using System.Data;

namespace ORBITA.DAL
{
    /// <summary>
    /// 产品管理 DAL
    /// </summary>
    public class ProductService
    {
        #region Public Methods

        /// <summary>
        /// 查询产品 所有数据
        /// </summary>
        /// <param name="pc_id"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns>ProductCollection 包含所有记录</returns>
        public static ProductCollection GetList(int pc_id, int startRowIndex, int maximumRows)
        {

            int iStartRowIndex = -1;
            int iMaximumRows = -1;

            if (startRowIndex > 0 && maximumRows > 0)
            {
                iStartRowIndex = startRowIndex;
                iMaximumRows = maximumRows;
            }

            ProductCollection list = new ProductCollection();

            string sql = @"SELECT
		                        prod_id, 
		                        prod_name, 
		                        prod_number, 
		                        prod_price, 
		                        prod_image, 
		                        prod_content, 
		                        prod_date, 
		                        prod_click, 
		                        istop, 
		                        iscommend, 
		                        pc_id
	                        FROM 
                            (
                                select 
                                   *, (select iif(isnull(sum(1)), 1, sum(1) + 1) 
                                        from T_Product 
                                        where (@pc_id=0 or pc_id=@pc_id) and prod_id > a.prod_id) as RowRank
                                from T_Product a 
                                where 
                                @pc_id=0
                                or
                                pc_id in (select pc_id from (select pc_id from T_ProductClass where PC_Id=@pc_id
                                                         union all
                                                         select p.pc_id 
                                                         from T_ProductClass p 
                                                         inner join
                                                         (select pc_id
                                                         from T_ProductClass
                                                         where PC_Id=@pc_id) t on p.Parent_Id = t.pc_id) as temp) 
                                order by prod_id desc
                            ) 
                            as ProductWithRowNumbers
                            where 
                            ((RowRank between @startRowIndex AND @startRowIndex + @maximumRows - 1)
			                            OR @startRowIndex = -1 OR @maximumRows = -1)";

            OleDbParameter[] parms = {
                                         new OleDbParameter("@pc_id",OleDbType.Integer),
                                         new OleDbParameter("@startRowIndex",OleDbType.Integer),
                                         new OleDbParameter("@maximumRows",OleDbType.Integer)
                                     };
            parms[0].Value = pc_id;
            parms[1].Value = iStartRowIndex;
            parms[2].Value = iMaximumRows;

            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms);
            if (reader.HasRows)
            {
                list = new ProductCollection();
                while (reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();

            return list;
        }

        /// <summary>
        /// 条件查询产品
        /// </summary>
        /// <param name="istop">置顶</param>
        /// <param name="iscommend">推荐</param>
        /// <returns>ProductCollection 包含条件查询的记录</returns>
        public static ProductCollection GetList(bool istop, bool iscommend)
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

            ProductCollection list = null;

            string sql = "select * from T_Product where IsTop=@IsTop and IsCommend=@IsCommend";
            OleDbParameter[] parms = { 
                                        new OleDbParameter("@IsTop",OleDbType.Boolean),
                                        new OleDbParameter("@IsCommend",OleDbType.Boolean)
                                     };
            parms[0].Value = bIsTop;
            parms[1].Value = bIsCommend;

            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms);
            if (reader.HasRows)
            {
                list = new ProductCollection();
                while (reader.Read())
                {
                    list.Add(FillDataRecord(reader));
                }
            }
            reader.Close();

            return list;
        }

        /// <summary>
        /// 条件查询产品
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>Product模型 包含一条产品记录</returns>
        public static Product GetItem(int prod_id)
        {
            Product myProduct = new Product();
            string sql = "select * from T_Product where prod_id=@prod_id";
            OleDbParameter[] parms = { new OleDbParameter("@prod_id", OleDbType.Integer) };
            parms[0].Value = prod_id;
            OleDbDataReader reader = DbHelper.ExecuteDataReader(sql, parms);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    myProduct = FillDataRecord(reader);
                }
            }

            reader.Close();

            return myProduct;
        }

        /// <summary>
        /// 删除一条产品记录
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>返回<c>true</c>删除成功，或,<c>false</c>删除失败.</returns>
        public static bool Delete(int prod_id)
        {
            int result = 0;
            string sql = "delete from T_Product where prod_id=@prod_id";
            OleDbParameter[] parms = { new OleDbParameter("@prod_id", OleDbType.Integer) };
            parms[0].Value = prod_id;
            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        /// <summary>
        /// 修改产品点击数
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        public static bool Update(int prod_id)
        {
            int result = 0;
            string sql = "update T_Product set prod_click=prod_click+1 where prod_id=@prod_id";
            OleDbParameter[] parms = { new OleDbParameter("@prod_id", OleDbType.Integer) };
            parms[0].Value = prod_id;
            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="myProduct">产品模型</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        public static bool Update(Product myProduct)
        {
            int result = 0;
            string sql = @"update T_Product 
                          set 
                                prod_name = @prod_name, 
		                        prod_number = @prod_number, 
		                        prod_price = @prod_price, 
		                        prod_image = @Prod_image, 
		                        prod_content = @prod_content, 
		                        prod_date = @prod_date, 
		                        prod_click = @prod_click, 
		                        istop = @istop, 
		                        iscommend = @iscommend, 
		                        pc_id = @pc_id
	                        WHERE
		                        prod_id = @prod_id";
            OleDbParameter[] parms = { 
                                        new OleDbParameter("@prod_name",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_number",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_price",OleDbType.Numeric),
                                        new OleDbParameter("@prod_image",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_content",OleDbType.LongVarWChar),
                                        new OleDbParameter("@prod_date",OleDbType.Date),
                                        new OleDbParameter("@prod_click",OleDbType.Integer),
                                        new OleDbParameter("@istop",OleDbType.Boolean),
                                        new OleDbParameter("@iscommend",OleDbType.Boolean),
                                        new OleDbParameter("@pc_id",OleDbType.Integer),
                                        new OleDbParameter("@prod_id",OleDbType.Integer)
                                     };
            
            parms[0].Value = myProduct.Prod_Name;
            parms[1].Value = myProduct.Prod_Number;
            parms[2].Value = myProduct.Prod_Price;
            parms[3].Value = myProduct.Prod_Image;
            parms[4].Value = myProduct.Prod_Content;
            parms[5].Value = myProduct.Prod_Date;
            parms[6].Value = myProduct.Prod_Click;
            parms[7].Value = myProduct.IsTop;
            parms[8].Value = myProduct.IsCommend;
            parms[9].Value = myProduct.Pc_Id;
            parms[10].Value = myProduct.Prod_Id;

            result = DbHelper.ExecuteNonQuery(sql, parms);

            return result > 0;
        }

        /// <summary>
        /// 插入产品记录
        /// </summary>
        /// <param name="myProduct">myProduct 模型</param>
        /// <returns>返回<c>true</c>插入成功，或<c>false</c>插入失败.</returns>
        public static bool Insert(Product myProduct)
        {
            int result = 0;
            string sql = @"insert into T_Product(         
            			                            prod_name, 
			                                        prod_number, 
			                                        prod_price, 
			                                        prod_image, 
			                                        prod_content, 
			                                        prod_date, 
			                                        prod_click, 
			                                        istop, 
			                                        iscommend, 
			                                        pc_id 
                                                ) 
                                                values 
                                                (
                                                    @prod_name, 
			                                        @prod_number, 
			                                        @prod_price, 
			                                        @prod_image, 
			                                        @prod_content, 
			                                        @prod_date, 
			                                        @prod_click, 
			                                        @istop, 
			                                        @iscommend, 
			                                        @pc_id
                                                )";
            OleDbParameter[] parms = { 
                                        new OleDbParameter("@prod_name",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_number",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_price",OleDbType.Numeric),
                                        new OleDbParameter("@prod_image",OleDbType.VarWChar),
                                        new OleDbParameter("@prod_content",OleDbType.LongVarWChar),
                                        new OleDbParameter("@prod_date",OleDbType.Date),
                                        new OleDbParameter("@prod_click",OleDbType.Integer),
                                        new OleDbParameter("@istop",OleDbType.Boolean),
                                        new OleDbParameter("@iscommend",OleDbType.Boolean),
                                        new OleDbParameter("@pc_id",OleDbType.Integer),
                                     };
            parms[0].Value = myProduct.Prod_Name;
            parms[1].Value = myProduct.Prod_Number;
            parms[2].Value = myProduct.Prod_Price;
            parms[3].Value = myProduct.Prod_Image;
            parms[4].Value = myProduct.Prod_Content;
            parms[5].Value = myProduct.Prod_Date;
            parms[6].Value = myProduct.Prod_Click;
            parms[7].Value = myProduct.IsTop;
            parms[8].Value = myProduct.IsCommend;
            parms[9].Value = myProduct.Pc_Id;

            result = DbHelper.ExecuteNonQuery(sql, parms);

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
