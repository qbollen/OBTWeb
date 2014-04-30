using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ORBITA.Model;
using ORBITA.DAL;

namespace ORBITA.BLL
{
    /// <summary>
    /// Product Bll.
    /// </summary>
    [DataObjectAttribute()]
    public class ProductManage
    {
        #region Public Methods

        /// <summary>
        /// 查询分类产品 带分页 所有数据.
        /// </summary>
        /// <param name="pc_id">产品分类id</param>
        /// <param name="startRowIndex">起始记录</param>
        /// <param name="maximumRows">最多记录数</param>
        /// <returns>产品list</returns>
        [DataObjectMethod(DataObjectMethodType.Select,true)]
        public static ProductCollection GetList(int pc_id, int startRowIndex, int maximumRows)
        {
            return ProductService.GetList(pc_id, startRowIndex, maximumRows);
        }

        /// <summary>
        /// 查询分类产品 无分页 所有数据.
        /// </summary>
        /// <param name="pc_id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static ProductCollection GetList(int pc_id)
        {
            return ProductService.GetList(pc_id,0,0);
        }

        /// <summary>
        /// 查询分类产品 无分页 所有数据.
        /// </summary>
        /// <param name="istop">置顶</param>
        /// <param name="iscommend">推荐</param>
        /// <returns>产品list</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static ProductCollection GetList(bool istop, bool iscommend)
        {
            return ProductService.GetList(istop,iscommend);
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static ProductCollection GetCommend()
        {
           ProductCollection list = ProductService.GetCommend();
           int length = list.Count;
           if (length < 18)
           {
               int i = 0;
               while(i < 18 - length)
               {
                   Product product = new Product();
                   list.Add(product);

                   i++;
               }
           }

           return list;
        }

        /// <summary>
        /// 查询产品记录.
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>Product模型 包含一条产品记录.</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static Product GetItem(int prod_id)
        {
            return ProductService.GetItem(prod_id);
        }

        /// <summary>
        /// 删除一条产品记录.
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>返回<c>true</c>删除成功,或<c>false</c>删除失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public static bool Delete(int prod_id)
        {
            return ProductService.Delete(prod_id);
        }

        /// <summary>
        /// 增加产品点击数.
        /// </summary>
        /// <param name="prod_id">产品id</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public static bool Update(int prod_id)
        {
            return ProductService.Update(prod_id);
        }

        /// <summary>
        /// 修改产品记录
        /// </summary>
        /// <param name="myProduct">Product模型</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update,true)]
        public static bool Update(Product myProduct)
        {
            if(myProduct.Prod_Id > 0
                && !string.IsNullOrEmpty(myProduct.Prod_Name)
                && !string.IsNullOrEmpty(myProduct.Prod_Content)
                && myProduct.Pc_Id > 0)
            {
                myProduct.Prod_Date = DateTime.Now;
                return ProductService.Update(myProduct);
            }
            else
            {
                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public static bool Insert(Product myProduct)
        {
            if(!string.IsNullOrEmpty(myProduct.Prod_Name)
                && !string.IsNullOrEmpty(myProduct.Prod_Content)
                && myProduct.Pc_Id > 0)
            {
                myProduct.Prod_Date = DateTime.Now;
                return ProductService.Insert(myProduct);
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
