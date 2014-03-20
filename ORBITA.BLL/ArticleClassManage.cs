using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using ORBITA.DAL;
using ORBITA.Model;
using System.Data;

namespace ORBITA.BLL
{/// <summary>
    /// ArticleClass Bll .
    /// </summary>

    [DataObjectAttribute()]
    public static class ArticleClassManage
    {
        #region Public Methods

        /// <summary>查询文章分类 所有数据.</summary>
        /// <returns>文章分类 list</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ArticleClassCollection GetList()
        {
            return ArticleClassService.GetList();
        }


        /// <summary>条件查询文章分类 </summary>
        /// <param name="parent_id">父亲ID</param>
        /// <returns>ArticleClassCollection 包含条件查询的记录.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ArticleClassCollection GetListByParentID(int parent_id)
        {
            return ArticleClassService.GetListByParentID(parent_id);
        }


        /// <summary>条件查询文章分类 </summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>ArticleClass模型 包含一条文章分类记录.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ArticleClass GetItem(int ac_id)
        {
            return ArticleClassService.GetItem(ac_id);
        }


        /// <summary>查询文章分类树 </summary>
        /// <returns>DataSet 包含文章分类树记录.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static DataSet GetTree()
        {
            return ArticleClassService.GetTree();
        }


        /// <summary>删除一条文章分类记录</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>返回 <c>true</c> 删除成功, 或 <c>false</c> 删除失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(int ac_id)
        {
            if (IsLeafNode(ac_id))
            {
                return ArticleClassService.Delete(ac_id);
            }
            else
            {
                return false;
            }
        }

        /// <summary>修改文章分类记录</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <param name="ac_name">文章分类名称</param>
        /// <returns>返回 <c>true</c> 修改成功, 或 <c>false</c> 修改失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Update(int ac_id, string ac_name)
        {
            ArticleClass myArticleClass = new ArticleClass();
            if (ac_id > 0 && !string.IsNullOrEmpty(ac_name))
            {
                myArticleClass.ac_id = ac_id;
                myArticleClass.ac_name = ac_name;
                return ArticleClassService.Update(myArticleClass);
            }
            else
            {
                return false;
            }
        }

        /// <summary>插入文章分类记录</summary>
        /// <param name="myArticleClass">ArticleClass 模型</param>
        /// <returns>返回 <c>true</c> 插入成功, 或 <c>false</c> 插入失败.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static bool Insert(ArticleClass myArticleClass)
        {
            if (!string.IsNullOrEmpty(myArticleClass.ac_name))
            {
                return ArticleClassService.Insert(myArticleClass);
            }
            else
            {
                return false;
            }
        }


        /// <summary>判断分类是否是叶子接点</summary>
        /// <param name="ac_id">文章分类ID</param>
        /// <returns>返回 <c>true</c> 是叶子接点, 或 <c>false</c> 非叶子接点.</returns>
        public static bool IsLeafNode(int ac_id)
        {
            if (GetListByParentID(ac_id).Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary> 获得文章类导航链接 </summary> 
        /// <param name="ac_id">产品分类ID</param> 
        /// <param name="str">存储链接的字符串</param> 
        /// <returns>返回已装载链接的字符串</returns>
        public static string ArticleClassNav(int ac_id, string str)
        {
            ArticleClass myArticleClass = GetItem(ac_id);

            if (myArticleClass.ac_id > 0)
            {
                str = " >> " + string.Format("<a href='ArticleList.aspx?id={0}'>{1}</a>", myArticleClass.ac_id, myArticleClass.ac_name)
                    + str;
                str = ArticleClassNav(myArticleClass.parent_id, str);
            }
            return str;
        }

        #endregion

    }
}
