using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORBITA.Model;
using System.ComponentModel;
using ORBITA.DAL;
using System.Data;

namespace ORBITA.BLL
{
    /// <summary>
    /// ProductClass Bll.
    /// </summary>
    [DataObjectAttribute()]
    public class ProductClassManage
    {
        #region Public Methods
        /// <summary>
        /// 查询产品分类 所有数据
        /// </summary>
        /// <returns>产品分类 list</returns>
        [DataObjectMethod(DataObjectMethodType.Select,true)]
        public static ProductClassCollection GetList()
        {
            return ProductClassService.GetList();
        }

        /// <summary>
        /// 条件查询产品分类
        /// </summary>
        /// <param name="parent_id">父亲id</param>
        /// <returns>ProductClassCollection 包含条件查询的记录</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static ProductClassCollection GetListByParentID(int parent_id)
        {
            return ProductClassService.GetListByParentId(parent_id);
        }

        /// <summary>
        /// 条件查询产品分类
        /// </summary>
        /// <param name="pc_id">产品分类id</param>
        /// <returns>ProductClass模型 包含一条产品分类记录</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static ProductClass GetItem(int pc_id)
        {
            return ProductClassService.GetItem(pc_id);
        }

        /// <summary>
        /// 查询产品分类树
        /// </summary>
        /// <returns>DataSet 包含产品分类树记录</returns>
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public static DataSet GetTree()
        {
            return ProductClassService.GetTree();
        }

        /// <summary>
        /// 删除一条产品分类记录
        /// </summary>
        /// <param name="pc_id">产品分类id</param>
        /// <returns>返回<c>true</c>删除成功,或<c>false</c>删除失败</returns>
        [DataObjectMethod(DataObjectMethodType.Delete,true)]
        public static bool Delete(int pc_id)
        {
            if (IsLeafNode(pc_id))
            {
                return ProductClassService.Delete(pc_id);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改产品分类记录
        /// </summary>
        /// <param name="pc_id">产品分类id</param>
        /// <param name="pc_name">产品分类名称</param>
        /// <returns>返回<c>true</c>修改成功，或<c>false</c>修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update,true)]
        public static bool Update(int pc_id, string pc_name)
        {
            ProductClass myProductClass = new ProductClass();
            if (pc_id > 0 && !string.IsNullOrEmpty(pc_name))
            {
                myProductClass.PC_Id = pc_id;
                myProductClass.PC_Name = pc_name;
                return ProductClassService.Update(myProductClass);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 插入产品分类记录
        /// </summary>
        /// <param name="myProductClass">ProductClass 模型</param>
        /// <returns>返回<c>true</c>插入成功,或<c>false</c>插入失败</returns>
        [DataObjectMethod(DataObjectMethodType.Insert,true)]
        public static bool Insert(ProductClass myProductClass)
        {
            if (!string.IsNullOrEmpty(myProductClass.PC_Name))
            {
                return ProductClassService.Insert(myProductClass);
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 判断分类是否是叶子节点
        /// </summary>
        /// <param name="pc_id">分类id</param>
        /// <returns>返回<c>true</c>叶子节点,或<c>false</c>非叶子节点.</returns>
        public static bool IsLeafNode(int pc_id)
        {
            if (GetListByParentID(pc_id).Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得产品类导航链接
        /// </summary>
        /// <param name="pc_id">产品分类id</param>
        /// <param name="str">存储链接的字符串</param>
        /// <returns>返回已装载链接的字符串</returns>
        public static string ProductClassNav(int pc_id, string str)
        {
            ProductClass myProductClass = GetItem(pc_id);

            if (myProductClass.PC_Id > 0)
            {
                str = " > " + string.Format("<a href='ProductList.aspx?id={0}'>{1}</a>", myProductClass.PC_Id, myProductClass.PC_Name) +str;
                str = ProductClassNav(myProductClass.Parent_Id, str);
            }

            return str;
        }

        public static bool IsParentClass(int pc_id)
        {
            List<int> list = ProductClassService.GetParentClassList();
            return list.Contains(pc_id);
        }

        #endregion
    }
}
